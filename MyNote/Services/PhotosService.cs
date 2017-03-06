using MyNote.Entities;
using MyNote.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyNote.Services
{
    public class PhotosService : IPhotosService
    {
        private readonly IPhotosRepository _photosRepository;

        public PhotosService(IPhotosRepository photosRepository)
        {
            _photosRepository = photosRepository;
        }

        public string UploadImageToTempDirAndReturPhotoname(HttpPostedFile fileUpload)
        {
            string imageName = GetUniqueImageName(fileUpload.FileName);
            string tempImageDirectoryPath = GetTempImageDirectoryPath(imageName);
            fileUpload.SaveAs(tempImageDirectoryPath);

            return imageName;
        }

        public void InsertPhotos(int eventId, List<string> photoNames)
        {
            var photoList = GetPhotoList(eventId, photoNames);
            foreach (var photo in photoList)
            {
                _photosRepository.Insert(photo);
            }
        }

        public string GetUniqueImageName(string fileName)
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

        public List<Photo> GetPhotoList(int eventId, List<string> photoNames)
        {
            List<Photo> photoList = new List<Photo>();

            foreach (string name in photoNames)
            {
                photoList.Add(new Photo()
                {
                    EventId = eventId,
                    PhotoName = name
                });
            }

            return photoList;
        }

        public byte[] GetPhotoData(int photoId)
        {
            var photo = _photosRepository.GetPhoto(photoId);
            if (photo == null)
            {
                return null;
            }
            var photoData = File.ReadAllBytes(GetImageDirectoryPath(photo.PhotoName));

            return photoData;
        }
    }
}