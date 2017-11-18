using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserFormula.Models
{
    public class UserFormContext : DbContext
    {
        public UserFormContext() : base ("UserFormDB")
        {

        }

        public DbSet<UserFormula> Forms { get; set; }

    }
}