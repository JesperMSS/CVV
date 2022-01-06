using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CVSITEHT2021.Models
{
    public class CV
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }

        public string Mail { get; set; }

        public string Education { get; set; }

        public string Workplace { get; set; }

        public string Competences { get; set; }

        public string ImagePath { get; set; }

        [DisplayName("Private profile")]

        public bool PrivateProfile { get; set; }

        public CV()
        {

        }

        public virtual ICollection<Project> Projects { get; set; }

    }
}