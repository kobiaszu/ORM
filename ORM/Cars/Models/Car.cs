using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}