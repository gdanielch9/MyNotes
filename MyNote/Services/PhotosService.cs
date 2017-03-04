using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyNote.Services
{
    public class PhotosService : IPhotosService
    {
        public void UploadImageToTempDir(HttpPostedFile fileUpload)
        {
            string imageName = GetUniqueImageName(fileUpload.FileName);
            string tempImageDirectoryPath = GetTempImageDirectoryPath(imageName);
            fileUpload.SaveAs(tempImageDirectoryPath);
        }

        private string GetUniqueImageName(string fileName)
        {
            string uniqueImageName = Guid.NewGuid().ToString() + "_" + fileName;
            return uniqueImageName;
        }

        public string GetTempImageDirectoryPath(string imageName)
        {
            string imagePath = ConfigurationManager.AppSettings["tempImageDirectoryPath"] + "//" + imageName;
            return imagePath;
        }

        public string GetImageDirectoryPath(string imageName)
        {
            string imagePath = ConfigurationManager.AppSettings["imageDirectoryPath"] + "//" + imageName;
            return imagePath;
        }
    }
}