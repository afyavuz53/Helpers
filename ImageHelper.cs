using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArtworkForShare.UI.MVC.Helper
{
    public static class ImageHelper
    {
        [Obsolete]
        public static string GetImageUrl(IFormFile file, IHostingEnvironment environment)
        {
            string filePath = Path.Combine(environment.WebRootPath, "Content/Images");//../wwwroot/content/images
            string newName = string.Empty;
            if (file != null)
            {
                string dosya = file.FileName;
                string[] dosyaArray = dosya.Split('.');//görselin uzantısını yakalamak için dosya adı noktaya(.) göre iki diziye ayrılır. 
                newName = Guid.NewGuid().ToString() + "." + dosyaArray[dosyaArray.Length - 1];//resme rasgele ad verilerek yeni adı uzantısı ile beraber atanır.

                using (var fileStream = new FileStream(Path.Combine(filePath, newName), FileMode.Create))//görseli belirtilen dosya yoluna yeni adı ile kaydeder.
                {
                    file.CopyTo(fileStream);
                }
            }
            return "../../Content/Images/"+newName;//"../../Content/Images/[dosya adı].[uzantı]"
        }
    }
}
