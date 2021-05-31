using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DataTransferObject;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService) : this(productDal)
        {
            _categoryService = categoryService;
        }
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        private IResult BaseProcess(bool success, string message = null)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(x => x.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.Product.ProductNameExists);
            }
            return new SuccessResult();
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            var result = CheckIfProductNameExists(product.ProductName);
            if (result.Success)
            {
                return BaseProcess(_productDal.Add(product),Messages.Product.Added);
            }
            return result;
        }

        public IResult Delete(int id)
        {
            return BaseProcess(_productDal.Delete(new Product { ProductID = id }), Messages.Product.Deleted);
        }

        public IDataResult<Product> GetProduct(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductID == productId), Messages.Product.Listed);
        }

        public IDataResult<List<Product>> GetProducts()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.Product.ProductsListed);
        }

        public IDataResult<List<Product>> GetProductsByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == categoryId), Messages.Product.ProductsListed);
        }

        public IDataResult<List<RecipeProductDTO>> GetProductsByRecipe(int recipeId)
        {
            return new SuccessDataResult<List<RecipeProductDTO>>(_productDal.GetProductsByRecipe(recipeId), Messages.Product.Listed);
        }

        public IResult Update(Product product)
        {
            return BaseProcess(_productDal.Update(product), Messages.Product.Updated);
        }
    }
}
