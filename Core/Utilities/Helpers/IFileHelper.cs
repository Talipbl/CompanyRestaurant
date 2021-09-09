using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
    public interface IFileHelper
    {
        IResult CheckFileTypeValid(string type);
        void CreateFile(string directory, IFormFile file);
        IResult Upload(IFormFile file);
    }
}
