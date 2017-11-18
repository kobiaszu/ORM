using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;

namespace ORM1.Models
{
    public class ZakupyContext: DbContext
    {
        public ZakupyContext() : base("DbTestZakupy")
        {

        }
        public DbSet<Produkt> Zakupy { get; set; }
    }
}