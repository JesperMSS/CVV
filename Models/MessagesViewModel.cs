using System.ComponentModel.DataAnnotations;

namespace CVSITEHT2021.Models
{

    public class MessagesViewModel
    {
        [Key]
        public int MessageID { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }

        public int Reciver { get; set; }
        [Required]
        [Display(Name = "Name: ")]
        public string Sender { get; set; }
    }
}