using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel;

namespace CVSITEHT2021.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public bool isRead { get; set; }

        public string Sender { get; set; }

        [ForeignKey("CV")]
        public int CVId { get; set; }

        public virtual CV CV { get; set; }
    }
}