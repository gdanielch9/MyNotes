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
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }
    }
}