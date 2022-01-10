using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel;

namespace data.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [DisplayName("Title")]
        public string title { get; set; }

        [DisplayName("Content")]
        public string content { get; set; }

        [DisplayName("Read")]
        public bool isRead { get; set; }

        public string Sender { get; set; }

        [ForeignKey("CV")]
        public int CVId { get; set; }

        public virtual CV CV { get; set; }
    }
}