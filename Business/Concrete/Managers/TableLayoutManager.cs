using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IResult Upload(IFormFile file, string directory = null)
        {
            var result = _fileHelper.Upload(file, directory);
            if (result.Success)
            {
                Add(result.Message);
            }
            return new ErrorResult(result.Message);
        }

        public IDataResult<List<TableLayout>> GetLayouts()
        {
            List<TableLayout> pathLayouts = new List<TableLayout>();
            TableLayout tableLayout;
            var result = _tableLayoutDal.GetAll();
            if (result != null)
            {
                foreach (var path in result)
                {
                    tableLayout = new TableLayout();
                    tableLayout.LayoutID = path.LayoutID;
                    tableLayout.LayoutPath = FileHelper.GetCustomDirectory.Replace("\\", "/") + path.LayoutPath;
                    pathLayouts.Add(tableLayout);
                }
            }

            return new SuccessDataResult<List<TableLayout>>(pathLayouts);
        }

        public IResult Add(string directory)
        {
            TableLayout tableLayout = new TableLayout()
            {
                LayoutPath = directory
            };
            return BaseProcess(_tableLayoutDal.Add(tableLayout), Messages.Added);
        }
    }
}
