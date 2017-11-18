using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORM1.Models
{
    public class Produkt
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public int ilosc { get; set; }
        public DateTime Data { get; set; }
    }
}