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
using System.Text;

namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService):this(productDal)
        {
            _categoryService = categoryService;
        }
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        private IResult BaseProccess(bool success, string message = null)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            return BaseProccess(_productDal.Add(product));
        }

        public IResult Delete(int id)
        {
            return BaseProccess(_productDal.Delete(new Product { ProductID = id }), Messages.Product.Deleted);
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
            return BaseProccess(_productDal.Update(product), Messages.Product.Updated);
        }
    }
}
