using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.Methods.ApiProcessors;
using WebUI.Models;
using WebUI.Models.DataTransferObjects;
using WebUI.Models.Managers;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        string _url = "https://localhost:44396/";
        OrderDetailController _orderDetailController;
        ProductProcessor _productProcessor;
        OrderProcessor _orderProcessor;
        TableProcessor _tableProcessor;

        public OrderController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = Token.GetToken(contextAccessor);
            _productProcessor = new ProductProcessor(_url,accessToken);
            _orderProcessor = new OrderProcessor(_url, accessToken);
            _orderDetailController = new OrderDetailController(contextAccessor);
            _tableProcessor = new TableProcessor(_url,accessToken);
        }

        [HttpGet]
        public async Task<ActionResult> TableList()
        {
            TableViewModel model = new TableViewModel()
            {
                Tables = await _tableProcessor.GetTables()
            };
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> List(int tableId, DateTime orderDate)
        {
            TabManager tabManager;
            if (HttpContext.Session.GetObject<TabManager>("tab" + tableId) == null)
            {
                tabManager = new TabManager();
                Table table = await _tableProcessor.GetTableAsync(tableId);
                table.Status = false;
                await _tableProcessor.SetStatusAsync(table);
            }
            else
            {
                tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId) as TabManager;
            }
            Order order = new Order();
            order.EmployeeId = HttpContext.Session.GetObject<EmployeeSessionDTO>("user").Employee.EmployeeID;
            order.TableId = tableId;
            if (orderDate.Year == 0001)
            {
                orderDate = DateTime.Now;
            }
            order.OrderDate = orderDate;
            OrderViewModel model = new OrderViewModel()
            {
                Order = order,
                Products = (await _productProcessor.GetProductsAsync()).ToList(),
                TabManager = tabManager
            };
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> AddTab(int productId, int tableId, DateTime orderDate)
        {
            TabManager tabManager;
            if (HttpContext.Session.GetObject<TabManager>("tab" + tableId) == null)
            {
                tabManager = new TabManager();
            }
            else
            {
                tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId) as TabManager;
            }

            Product product = await _productProcessor.GetProductAsync(productId);
            Tab tab = new Tab();

            tab.ID = product.ProductID;
            tab.Name = product.ProductName;
            tab.SubPrice = (decimal)product.UnitPrice;

            tabManager.Add(tab);
            HttpContext.Session.SetObject("tab" + tableId, tabManager);
            return RedirectToAction("List", "Order", new { tableId = tableId, orderDate = orderDate });
        }

        [HttpGet]
        public ActionResult DeleteTab(int id, int tableId)
        {
            TabManager tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId) as TabManager;

            tabManager.Delete(id);

            return RedirectToAction("List", "Order", tableId);
        }

        [HttpPost]
        public ActionResult UpdateTab(int tableId, params short[] amounts)
        {
            TabManager tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId) as TabManager;

            tabManager.Update(amounts);

            return RedirectToAction("Order", "Add");
        }

        [HttpGet]
        public async Task<ActionResult> OrderCheckout(int tableId)
        {
            TabManager tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId) as TabManager;
            DateTimeDTO dateTime = new DateTimeDTO()
            {
                DateTime = DateTime.Now
            };
            Order order = new Order()
            {
                EmployeeId = HttpContext.Session.GetObject<EmployeeSessionDTO>("user").Employee.EmployeeID,
                TableId = tableId,
                OrderDate = dateTime.DateTime,
                TotalPrice = tabManager.TotalPrice
            };
            if((await _orderProcessor.AddOrderAsync(order))!="")
            {
                Order savedOrder = await _orderProcessor.GetLastOrderAsync();
                int orderId = savedOrder.OrderID;
                for (int i = 0; i < tabManager.Tabs.Count; i++)
                {
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        OrderID = orderId,
                        ProductID = tabManager.Tabs[i].ID,
                        Amount = tabManager.Tabs[i].SubPrice,
                        Quantity = tabManager.Tabs[i].Amount
                    };
                    _orderDetailController.AddOrderDetail(orderDetail);
                }
            }
            Table table = await _tableProcessor.GetTableAsync(tableId);
            table.Status = true;
            await _tableProcessor.SetStatusAsync(table);

            return RedirectToAction("Index", "Home");
        }
    }
}
