using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CShap_MVC_VuDoan.Models;

namespace CShap_MVC_VuDoan.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult List(Blogs blog)
        {
            return View(blog);
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(Blogs blog)
        {
            return View(blog);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(Blogs blog)
        {
            return View(blog);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Blogs blog)
        {
            return View(blog);
        }
    }
}