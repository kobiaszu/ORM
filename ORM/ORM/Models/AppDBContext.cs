using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ORM.Models
{
    public class AppDBContext: DbContext
    {
        public AppDBContext() : base("TestDB")
        {

        }

        public DbSet<TestDBModel> TestDBModels { get; set; }

        //public DbSet<Car> Cars { get; set; }

        //public DbSet<Owner> Owners { get; set; }

    }
}