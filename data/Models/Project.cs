using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace data.Models
{
    public class Project
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [DisplayName("Created by")]

        public string CreatedBy { get; set; }

        public virtual ICollection<CV> CVs { get; set; }


    }
}