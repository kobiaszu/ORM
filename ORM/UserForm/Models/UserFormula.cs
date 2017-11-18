using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserFormula.Models
{
    public class UserFormula
    {   
        public int ID { get; set; }

        [Required(ErrorMessage = "wpisz email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "wpisz temat")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "treść nie może być pusta")]
        public string Description { get; set; }

    }
}