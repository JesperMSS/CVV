using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace CVSITEHT2021.Models
{
    public class CvEditViewModel
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-mail")]
        public string Mail { get; set; }

        [DisplayName("Education")]
        public string Education { get; set; }

        [DisplayName("Workplace")]
        public string Workplace { get; set; }

        [DisplayName("Competences")]
        public string Competences { get; set; }

        [DisplayName("Image")]
        public HttpPostedFileBase Image { get; set; }
        public string ExistingImagePath { get; set; }

        [DisplayName("Private profile")]
        public bool PrivateProfile { get; set; }
    }

    public class CvDeleteModel
    {
        public int Id { get; set; }
    }
}