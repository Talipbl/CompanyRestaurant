using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRecipeService
    {
        IResult Add(Recipe recipe);
        IResult Delete(int recipeId);
        IResult Update(Recipe recipe);
        IDataResult<List<Recipe>> GetRecipes();
        IDataResult<Recipe> GetRecipe(int recipeId);
    }
}
