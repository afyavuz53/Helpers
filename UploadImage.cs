using CloudinaryDotNet;         //Paket yüklemeniz gerekli
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ava.UI.WinForm.Helper
{
    static class UploadImage
    {
        //https://cloudinary.com sitesini api servisini kullanarak görsel yükleme
        const string cloud_name = "......";                 //  Sitede açtığınızda
        const string api_key = "......";                    //  bu bilgileri 
        const string api_secret = "..........";             //  DashBoard ==>> Account Details de görebilirsiniz.

        [Obsolete]
        public static string UploadImageToCloudinary(string imagePath)//OpenFileDialog'dan çektiğiniz dosya yolu gönderilir...
        {
            Account account = new Account(cloud_name, api_key, api_secret);
            Cloudinary cloudinary = new Cloudinary(account);
            
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imagePath)
            };                        
            uploadParams.File.FileName = "[belgeadı]" //    isteğe bağlı yüklenecek görselin adı değiştirilebilir ya da 
            uploadParams.Folder = "[klasör adı]"      //    isteğe bağlı site içersinde klasöre yüklemek istediğinizde doldurabilirsiniz.
            var uploadResult = cloudinary.Upload(uploadParams); //    görselin yüklendiği url'i elde edebilirsiniz.
            return uploadResult.Uri.AbsoluteUri;      
        }
        [Obsolete]
        public async static Task<string> UploadImageToCloudinaryAsync(string imagePath) // aynı method'un asenkron hali.
        {
            Account account = new Account(cloud_name, api_key, api_secret);
            Cloudinary cloudinary = new Cloudinary(account);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(imagePath)
            };                      
            var uploadResult =await cloudinary.UploadAsync(uploadParams);
            return uploadResult.Uri.AbsoluteUri;
        }
    }
}
