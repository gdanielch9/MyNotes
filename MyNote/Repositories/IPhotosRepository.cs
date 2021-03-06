﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyNote.Entities;

namespace MyNote.Repositories
{
    public interface IPhotosRepository
    {
        void Insert(Photo photo);
        Photo GetPhoto(int photoId);
        void RemoveAndInsertPhotosByEventId(int eventId);
        void InsertNewPhotos(int eventId, List<Photo> photos);
        void RemoveDeletedPhotos(List<Photo> photos);
    }
}
