using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CVSITEHT2021.Models;

namespace CVSITEHT2021.Models

{
    public class CVDatabase : DbContext
    {


        public CVDatabase() : base("DefaultConnection")
        {
        }
        public DbSet<CV> cv { get; set; } 

    }
}