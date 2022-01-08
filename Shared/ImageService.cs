using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace CVSITEHT2021.Shared
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
    }
}