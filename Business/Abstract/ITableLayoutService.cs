using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ITableLayoutService
    {
        IDataResult<List<TableLayout>> GetLayouts();
        IResult Upload(IFormFile file, string directory = null);
        IResult Add(string directory);
    }
}
