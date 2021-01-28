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
                if (result != null)
                {
                    string a = "sdfsdf";
                    return RedirectToAction("List");
                }
                else
                {
                    TempData["result1"] = result;
                    string test = result;
                    ModelState.Clear();

                    return RedirectToAction("List");
                }                    
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

            blogsModel.ShowAllBlogs = blogsDAO.SearchData();
            return View(blogsModel);
        }

        [HttpPost]
        public ActionResult Search(Blogs blog)
        {
            if (ModelState.IsValid)
            {
                List<Blogs> blogs = null;
                BlogsDAO dao = new BlogsDAO();
                blogs = dao.SearchData();

                //TempData["result1"] = result;
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