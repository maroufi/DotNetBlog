using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posts__Comments.Models
{
    
    public class Comment
    {
        
        public int ID { get; set; }
        public string Text { get; set; }
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

    }
}