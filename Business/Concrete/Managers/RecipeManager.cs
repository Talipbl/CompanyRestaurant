using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class RecipeManager : IRecipeService
    {
        public IResult Add()
        {
            throw new NotImplementedException();
        }

        public IResult Delete()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Recipe> GetRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Recipe>> GetRecipes()
        {
            throw new NotImplementedException();
        }

        public IResult Update()
        {
            throw new NotImplementedException();
        }
    }
}
