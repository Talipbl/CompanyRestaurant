using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete.Managers
{
    public class TableLayoutManager : ITableLayoutService
    {
        ITableLayoutDal _tableLayoutDal;
        IFileHelper _fileHelper;
        public TableLayoutManager(ITableLayoutDal tableLayoutDal, IFileHelper fileHelper)
        {
            _tableLayoutDal = tableLayoutDal;
            _fileHelper = fileHelper;
        }
        private IResult BaseProcess(bool success, string message)
        {
            if (success)
            {
                return new SuccessResult(message);
            }
            return new ErrorResult();
        }

        public IResult Add(IFormFile file)
        {
            var result = _fileHelper.Upload(file);
            if (result.Success)
            {
                TableLayout tableLayout = new TableLayout()
                {
                    LayoutPath = result.Message
                };
                return BaseProcess(_tableLayoutDal.Add(tableLayout), Messages.Added);
            }
            return new ErrorResult(result.Message);
        }

        public IDataResult<List<TableLayout>> GetLayouts()
        {
            return new SuccessDataResult<List<TableLayout>>(_tableLayoutDal.GetAll());
        }
    }
}
