using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Posts__Comments.Models
{
    public class Post
    {
        public Post()
        {

        }
        public int ID { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public virtual System.Collections.Generic.ICollection<Comment> Comments { get; set; }
    }
}