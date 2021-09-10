using Core.Utilities.Constants.Messages;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper : IFileHelper
    {
        private static string CurrentDirectory = Environment.CurrentDirectory + "\\wwwroot";
        public static string GetCurrentDirectory 
        { 
            get
            {
                return CurrentDirectory;
            }
            private set { }
        }
        
        private static string _folderName = "\\images\\";

        public void CheckDirectoryExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        public IResult CheckFileTypeValid(string type)
        {
            if (type != ".jpeg" && type != ".png" && type != ".jpg")
            {
                return new ErrorResult(HelperMessage.WrongFileType);
            }
            return new SuccessResult();
        }

        public async void CreateFile(string directory, IFormFile file)
        {
            using (FileStream stream = File.Create(directory))
            {
                await file.CopyToAsync(stream);
                stream.Flush();//?
            }
        }

        public IResult Upload(IFormFile file, string directory = null)
        {
            if (file != null)
            {
                if (directory == null)
                {
                    directory = CurrentDirectory;
                }
                string imageExtension = Path.GetExtension(file.FileName);
                string imageName = Guid.NewGuid().ToString();

                var typeResult = CheckFileTypeValid(imageExtension);
                if (!typeResult.Success)
                {
                    return new ErrorResult(typeResult.Message);
                }

                CheckDirectoryExists(directory + _folderName);
                CreateFile(directory + _folderName + imageName + imageExtension, file);
                return new SuccessResult((_folderName + imageName + imageExtension).Replace("\\", "/"));
            }
            return new ErrorResult(HelperMessage.EmptyFile);
        }
    }
}
