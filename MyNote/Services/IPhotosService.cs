using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyNote.Services
{
    public interface IPhotosService
    {
        string UploadImageToTempDirAndReturPhotoname(HttpPostedFile fileUpload);
        void InsertPhotos(int eventId, List<string> photoNames);
        byte[] GetPhotoData(int photoId);
    }
}
