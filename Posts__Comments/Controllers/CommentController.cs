using Posts__Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posts__Comments.Controllers
{
    public class CommentController : Controller
    {
        static int PostID;
        Models.DataBaseContext db = new Models.DataBaseContext();
        //
        // GET: /Comment/
        public ActionResult Index(int postid)
        {
            PostID = postid;
            Post oPost = db.Posts.Find(postid);
            return View(oPost.Comments.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string text)
        {
            Comment oComment = new Comment();
            oComment.Text = text;
            oComment.PostID = PostID;
            db.Comments.Add(oComment);
            db.SaveChanges();
            return RedirectToAction("Index", new { PostID });
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Comments.Find(id));
        }
        [HttpPost]
        public ActionResult Edit(int id,string text)
        {
            Comment oComment = db.Comments.Find(id);
            oComment.Text = text;
            db.SaveChanges();
            return RedirectToAction("Index", new { postid = PostID });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(db.Comments.Find(id));
        }
        public ActionResult DeleteConfirmed(int id)
        {
            db.Comments.Remove(db.Comments.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index", new { postid = PostID });
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}