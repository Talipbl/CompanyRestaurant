using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetCategories();
        IDataResult<Category> GetCategory(int categoryId);

        IResult Add(Category category);
        IResult Delete(int categoryId);
        IResult Update(Category category);

    }
}
