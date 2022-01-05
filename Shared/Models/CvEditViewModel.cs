using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Shared
{
    public class CvEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Telefonnummer")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-mail")]
        public string Mail { get; set; }

        [DisplayName("Utbildning")]
        public string Education { get; set; }

        [DisplayName("Arbetsplats")]
        public string Workplace { get; set; }

        [DisplayName("Kompetenser")]
        public string Competences { get; set; }

        [DisplayName("Bild")]
        public HttpPostedFileBase Image { get; set; }
        public string ExistingImagePath { get; set; }
        public bool IsCreateCvView { get; set; }


    }

    public class CvDeleteModel
    {
        public int Id { get; set; }
    }
}