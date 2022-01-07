﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVSITEHT2021.Models
{

    public class MessagesViewModel
    {
        public int MessageID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Meddelandet måste minst vara {2} karaktärer långt.", MinimumLength = 3)]
        [Display(Name = "Innehåll:")]
        public string Content { get; set; }

        public int Reciver { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Ditt namn måste vara minst {2} karaktärer långt.", MinimumLength = 2)]
        [Display(Name = "Avsändare:")]
        public string Sender { get; set; }
    }
}