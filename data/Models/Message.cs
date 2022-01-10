using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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