using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using DoAn2.Models;

namespace DoAn2.Controllers
{
    public class DanhMucController : Controller
    {
        private DataContext db = new DataContext();

        public IActionResult Index()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Category model)
        {
            ViewBag.Categories = db.Categories.ToList();
            if (model.Id > 0) {
                Category dm = db.Categories.SingleOrDefault(x => x.Id == model.Id);
                dm.C_name = model.C_name;
                db.SaveChanges();

            }

            return View(model);
        }

        public IActionResult DeleteCategory(int Id)
        {
            bool result = false;
            var dm = (from d in db.Categories
                      where (d.Id == Id)
                      select d)
                      .FirstOrDefault();
            if(dm !=null)
            {
                db.Remove(dm);
                db.SaveChanges();
                result = true;
            }
            return Json(result);
        }
     
        [HttpPost]
        [Route("create")]
        public IActionResult Create(string C_name)
        {
            Category dm = new Category
            {
                C_name = C_name
            };
            db.Categories.Add(dm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
 
        public ActionResult AddEditCategory(int Id)
        {
            Category model  = new Category();


            if (Id > 0)
            {
                Category dm = db.Categories.SingleOrDefault(x => x.Id == Id);
               model.Id = dm.Id;
                model.C_name = dm.C_name;
            }
            return PartialView("AddEditCategory", model);
        }

    }
}
