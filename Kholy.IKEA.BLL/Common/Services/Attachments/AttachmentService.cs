using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Kholy.IKEA.BLL.Common.Services.Attachments
{


    public class AttachmentService : IAttachmentService
    {
        private readonly List<string> _allowedExtensions = new List<string>() { ".png", ".jpg", ".jpeg" };
        private int allowedMaxSize = 2_097_152; // 2 MB
        public bool Delete(string FilePath)
        {
            if(FilePath == null)
            {
                return false;
            }
            else
            {
                File.Delete(FilePath);
                return true;
            }
        }

        public string? Upload(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_allowedExtensions.Contains(extension))
            {
                return null;
            }
            if (file.Length > allowedMaxSize)
            {
                return null;
            }
            //var FolderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\Files{folderName}";
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            var FileName = $"{Guid.NewGuid()}{extension}";
            var FilePath = Path.Combine(FolderPath, FileName);

            //Streaming on the server

            using var filestream = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(filestream);

            return FileName;
        }
        #region Commented Code
        //    private readonly List<string> _allowedExtensions = new List<string>() { ".png", ".jpg", ".jpeg" };
        //    private const int _allowedMaxSize = 2_097_152;
        //    public bool Delete(string FilePath)
        //    {
        //        throw new NotImplementedException();
        //    }
        //    public string? Upload(IFormFile file, string folderName)
        //    {
        //        var extension = Path.GetExtension(file.FileName);

        //        if (!_allowedExtensions.Contains(extension))
        //        {
        //            return null;
        //        }
        //        if (file.Length > _allowedMaxSize)
        //        {
        //            return null;
        //        }

        //    }
        #endregion
    }
}
