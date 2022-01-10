using System;
using System.IO;
using System.Web;

namespace data.Shared
{
    public class ImageService
    {
        public static string GetImagePathRelative(string imagepath)
        {
            return $"/Images/{imagepath}";
        }

        public string SaveImageToDisk(HttpPostedFileBase httpPostedFile)
        {
            var folder = HttpContext.Current.Server.MapPath("~/Images");
            var filename = Guid.NewGuid().ToString().Substring(0, 4) + httpPostedFile.FileName;
            var path = Path.Combine(folder, filename);
            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
            httpPostedFile.SaveAs(path);
            return filename;
        }


        public bool RemoveImageFromDiskIfExists(string imagefilename)
        {
            var imagefolder = HttpContext.Current.Server.MapPath("~/Images");
            var fullpath = Path.Combine(imagefolder, imagefilename);
            try
            {
                if (File.Exists(fullpath))
                {
                    File.Delete(fullpath);
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }

        }
    }
}