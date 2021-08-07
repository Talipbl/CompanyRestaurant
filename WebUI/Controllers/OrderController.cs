﻿using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Methods;
using WebUI.ApiControllers.ApiProcessors;
using WebUI.Models;
using WebUI.Models.DataTransferObjects;
using WebUI.Models.Managers;
using WebUI.Models.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        string _url = "https://localhost:44396/";
        OrderDetailController _orderDetailController;
        ProductProcessor _productProcessor;
        OrderProcessor _orderProcessor;
        TableProcessor _tableProcessor;

        public OrderController(IHttpContextAccessor contextAccessor)
        {
            string accessToken = TokenHelper.GetToken(contextAccessor);
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
            if (HttpContext.Session.GetObject<TabManager>("tab" + tableId).Entity==null)
            {
                tabManager = new TabManager();
                ResponseDTO<Table> table = await _tableProcessor.GetTableAsync(tableId);
                table.Entity.Status = false;
                await _tableProcessor.SetStatusAsync(table.Entity);
            }
            else
                tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId).Entity as TabManager;
            Order order = new Order();
            order.EmployeeId = HttpContext.Session.GetObject<EmployeeSessionDTO>("user").Entity.Employee.EmployeeID;
            order.TableId = tableId;
            if (orderDate.Year == 0001) 
                    orderDate = DateTime.Now;
            order.OrderDate = orderDate;
            OrderViewModel model = new OrderViewModel()
            {
                Order = order,
                Products = (await _productProcessor.GetProductsAsync()).Entity.ToList(),
                TabManager = tabManager
            };
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> AddTab(int productId, int tableId, DateTime orderDate)
        {
            TabManager tabManager;
            if (HttpContext.Session.GetObject<TabManager>("tab" + tableId).Entity==null)
            {
                tabManager = new TabManager();
            }
            else
            {
                tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId).Entity as TabManager;
            }

            ResponseDTO<Product> product = await _productProcessor.GetProductAsync(productId);
            Tab tab = new Tab();

            tab.ID = product.Entity.ProductID;
            tab.Name = product.Entity.ProductName;
            tab.SubPrice = (decimal)product.Entity.UnitPrice;

            tabManager.Add(tab);
            HttpContext.Session.SetObject("tab" + tableId, tabManager);
            return RedirectToAction("List", "Order", new { tableId = tableId, orderDate = orderDate });
        }
        [HttpGet]
        public ActionResult DeleteTab(int id, int tableId)
        {
            TabManager tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId).Entity as TabManager;

            tabManager.Delete(id);

            return RedirectToAction("List", "Order", tableId);
        }

        [HttpPost]
        public ActionResult UpdateTab(int tableId, params short[] amounts)
        {
            TabManager tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId).Entity as TabManager;

            tabManager.Update(amounts);

            return RedirectToAction("Order", "Add");
        }
        [HttpGet]
        public async Task<ActionResult> OrderCheckout(int tableId)
        {
            TabManager tabManager = HttpContext.Session.GetObject<TabManager>("tab" + tableId).Entity as TabManager;
            DateTimeDTO dateTime = new DateTimeDTO()
            {
                DateTime = DateTime.Now
            };
            Order order = new Order()
            {
                EmployeeId = HttpContext.Session.GetObject<EmployeeSessionDTO>("user").Entity.Employee.EmployeeID,
                TableId = tableId,
                OrderDate = dateTime.DateTime,
                TotalPrice = tabManager.TotalPrice
            };
            if((await _orderProcessor.AddOrderAsync(order)).ResponseMessage.IsSuccessStatusCode)
            {
                ResponseDTO<Order> savedOrder = await _orderProcessor.GetLastOrderAsync();
                int orderId = savedOrder.Entity.OrderID;
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
            ResponseDTO<Table> table = await _tableProcessor.GetTableAsync(tableId);
            table.Entity.Status = true;
            await _tableProcessor.SetStatusAsync(table.Entity);

            HttpContext.Session.Remove("tab" + tableId);

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<ActionResult> CancelOrder(int tableId)
        {
            Table table = _tableProcessor.GetTableAsync(tableId).Result.Entity;
            table.Status = true;
            await _tableProcessor.SetStatusAsync(table);

            HttpContext.Session.Remove("tab" + tableId);
            return RedirectToAction(nameof(TableList));
        }
        [HttpGet]
        public async Task<ActionResult> ListOrders()
        {
            ResponseDTO<List<Order>> orders = await _orderProcessor.GetOrdersAsync();
            ListOrdersViewModel model = new ListOrdersViewModel
            {
                Orders = orders.Entity
            };
            return View(model);
        }
    }
}
