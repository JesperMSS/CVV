using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace data.Models
{
    public class CV
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [DisplayName("Phone number")]
        [RegularExpression(@"^(\+\d{1, 2}\s)?\(?\d{3}\)?[\s.-]\d{ 3}[\s.-]\d{ 4}$)")]
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