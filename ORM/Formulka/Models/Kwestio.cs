using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Formulka.Models
{
    public class Kwestio
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "wpisz email")]
        [EmailAddress]
        public string Email { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }
    }
}