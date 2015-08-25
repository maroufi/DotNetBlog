using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posts__Comments.Models
{
    public class DataBaseContext:System.Data.Entity.DbContext
    {
        static DataBaseContext()
        {
          

        }
        public System.Data.Entity.DbSet<Post> Posts { get; set; }
        public System.Data.Entity.DbSet<Comment> Comments { get; set; }
    }
}