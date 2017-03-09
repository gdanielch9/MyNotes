using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyNote.Entities;
using MyNote.Models;

namespace MyNote.Repositories
{
    public class PhotosRepository : IPhotosRepository
    {
        private readonly ApplicationDbContext _context;

        public PhotosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Photo GetPhoto(int photoId)
        {
            var photo = _context.Photos.SingleOrDefault(x => x.Id == photoId);
            return photo;
        }

        public void Insert(Photo photo)
        {
            if (!_context.Photos.Any(x => x.Id == photo.Id))
            {
                _context.Photos.Add(photo);
                _context.SaveChanges();
            }
        }

        public void InsertNewPhotos(int eventId, List<Photo> photos)
        {
            PhotoAndPhotoNamesComparer comparer = new PhotoAndPhotoNamesComparer();
            var newPhotos = photos.Except(_context.Photos, comparer);
            _context.Photos.AddRange(newPhotos);
            _context.SaveChanges();
        }

        public void RemoveAndInsertPhotosByEventId(int eventId)
        {
            var photos = _context.Photos.Where(x => x.EventId == eventId);
            foreach (var photo in photos)
            {
                _context.Photos.Remove(photo);
            }
            _context.SaveChanges();
        }

        public void RemoveDeletedPhotos(List<Photo> photosNames)
        {
            PhotoAndPhotoNamesComparer comparer = new PhotoAndPhotoNamesComparer();
            var photos = _context.Photos.ToList();
            var photosToRemove = photos.Except(photosNames, comparer);

            foreach (var ptr in photosToRemove)
            {
                _context.Photos.Remove(ptr);
            }
            _context.SaveChanges();
        }

        public class PhotoAndPhotoNamesComparer : IEqualityComparer<Photo>
        {
            public bool Equals(Photo photoX, Photo photoY)
            {
                return photoX.PhotoName == photoY.PhotoName;
            }

            public int GetHashCode(Photo photo)
            {
                return photo.PhotoName.GetHashCode();
            }
        }
    }
}