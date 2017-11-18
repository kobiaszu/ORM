using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Formulka.Models
{
    public class KwestioDBContext : DbContext
    {
        public KwestioDBContext() : base("KwestioBaza")
        {

        }

        public  DbSet<Kwestio> Kwestionariusze { get; set; }
    }
}