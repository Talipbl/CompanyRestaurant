using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class RecipeManager : IRecipeService
    {
        IRecipeDal _recipeDal;
        public RecipeManager(IRecipeDal recipeDal)
        {
            _recipeDal = recipeDal;
        }

        private IResult BaseProcess(bool success, string message)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }
        public IResult Add(Recipe recipe)
        {
            return BaseProcess(_recipeDal.Add(recipe), Messages.Added);
        }

        public IResult Delete(int recipeId)
        {
            return BaseProcess(_recipeDal.Delete(new Recipe { RecipeID = recipeId }), Messages.Deleted);
        }

        public IDataResult<Recipe> GetRecipe(int recipeId)
        {
            return new SuccessDataResult<Recipe>(_recipeDal.Get(x => x.RecipeID == recipeId),Messages.Listed);
        }

        public IDataResult<List<Recipe>> GetRecipes()
        {
            return new SuccessDataResult<List<Recipe>>(_recipeDal.GetAll(), Messages.AllListed);
        }

        public IResult Update(Recipe recipe)
        {
            return BaseProcess(_recipeDal.Update(recipe), Messages.Updated);
        }
    }
}
