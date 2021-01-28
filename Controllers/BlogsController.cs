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
            return View();
        }

        [HttpPost]
        public ActionResult New(Blogs blog)
        {
            if (ModelState.IsValid)
            {
                BlogsDAO dao = new BlogsDAO();
                string result = dao.InsertData(blog);

                TempData["result1"] = result;
                string test = result;
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
            BlogsDAO blogsDAO = new BlogsDAO();
            Blogs blogsModel = new Blogs();

            blogsModel.ShowAllBlogs = blogsDAO.ListData();
            return View(blogsModel);
        }

        [HttpPost]
        public ActionResult Search(string searchBlog)
        {
            if (ModelState.IsValid)
            {
                List<Blogs> blogs = null;
                BlogsDAO dao = new BlogsDAO();/*
                blogs = dao.SearchData(searchBlog);
                //TempData["result2"] = result;
                

                return RedirectToAction("Search");*/

                if (!String.IsNullOrEmpty(searchBlog))
                {
                    blogs = dao.SearchData(searchBlog);
                    ModelState.Clear();
                }

                return RedirectToAction("Search");
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return RedirectToAction("Search");
            }
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            return View(dao.SelectDataByID(id));
        }

        [HttpPost]
        public ActionResult Edit(Blogs blog)
        {
            if (ModelState.IsValid) //checking model is valid or not    
            {
                string result = dao.UpdateData(blog);
                TempData["result2"] = result;
                ModelState.Clear(); //clearing model    

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