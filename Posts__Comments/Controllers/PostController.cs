using Posts__Comments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Posts__Comments.Controllers
{
    public class PostController : Controller
    {
        private DataBaseContext db = new DataBaseContext();
        //
        // GET: /Post/
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(string topic , string text)
        {
            Post oPost = new Post();
            oPost.Text = text;
            oPost.Topic = topic;
            db.Posts.Add(oPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Post oPost = db.Posts.Find(id);
            return View(oPost);
        }
        public ActionResult DeleteConfirmed(int id)
        {
            Post oPost = db.Posts.Find(id);
            db.Posts.Remove(oPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Post oPost = db.Posts.Find(id);

            return View(oPost);
        }
        [HttpPost]
        public ActionResult Edit(int id,string topic,string text)
        {
            Post oPost = db.Posts.Find(id);
            oPost.Topic = topic;
            oPost.Text = text;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
	}
}