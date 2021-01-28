using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CShap_MVC_VuDoan.Models;
using CShap_MVC_VuDoan.DAO;

namespace CShap_MVC_VuDoan.Controllers
{
    public class BlogsController : Controller
    {
        BlogsDAO dao = new BlogsDAO();
        Blogs blogs = new Blogs();

        // GET: Blogs
        [HttpGet]
        public ActionResult List()
        {
            BlogsDAO blogsDAO = new BlogsDAO();
            Blogs blogsModel = new Blogs();

            blogsModel.ShowAllBlogs = blogsDAO.ListData();
            return View(blogsModel);
        }

        /*[HttpPost]
        public ActionResult List(Blogs blog)
        {
            
        }
*/
        [HttpGet]
        public ActionResult New()
        {
            Blogs blogs = new Blogs();
            return View(blogs);
        }

        [HttpPost]
        public ActionResult New(Blogs blog)
        {
            if (ModelState.IsValid)
            {
                BlogsDAO dao = new BlogsDAO();
                string result = dao.InsertData(blog);

                TempData["insertResult"] = result;
                ModelState.Clear();

                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }

        [HttpGet]
        public ActionResult Search()
        {
            blogs.ShowAllBlogs = dao.ListData();
            return View(blogs);
        }

        [HttpGet]
        public ActionResult SearchByTitle(string title)
        {
            blogs.ShowAllBlogs = dao.SearchData(title);
            return View(blogs);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(dao.SelectDataByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Blogs blog)
        {
            if (ModelState.IsValid)  
            {
                string result = dao.UpdateData(blog);
                TempData["updateResult"] = result;
                ModelState.Clear(); 

                return RedirectToAction("List");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }
        }
    }
}