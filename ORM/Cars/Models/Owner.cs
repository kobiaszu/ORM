using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cars.Models
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Car> CarList { get; set; }
    }
}