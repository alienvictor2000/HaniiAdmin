using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DoAn2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAn2.Controllers
{
    public class BaiVietController : Controller
    {
        private readonly DataContext db = new DataContext();
        private readonly IWebHostEnvironment _hostEnvironment;
        public BaiVietController(IWebHostEnvironment iweb)
        {
            _hostEnvironment = iweb;

        }


        public IActionResult Index()
        {
            ViewBag.Articles = db.Articles.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Article model)
        {
            try
            {
                List<Article> list = db.Articles.ToList();
                if (model.Id > 0)
                {
                    Article sp = db.Articles.SingleOrDefault(x => x.Id == model.Id);

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(model.A_avatar_file.FileName);
                    //  string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                    sp.A_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    model.A_avatar_file.CopyToAsync(fileStream);

                    sp.A_name = model.A_name;
                    sp.A_content = model.A_content;

                    db.SaveChanges();
                }
                else
                {
                    Article sp = new Article();

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(model.A_avatar_file.FileName);
                    //  string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                    sp.A_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    model.A_avatar_file.CopyToAsync(fileStream);

                    sp.A_name = model.A_name;
                    sp.A_content = model.A_content;

                    db.Articles.Add(sp);
                    db.SaveChanges();
                }
                ViewBag.Articles = db.Articles.ToList();

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IActionResult DeleteArticle(int Id)
        {
            bool result = false;
            var bv = (from a in db.Articles
                      where (a.Id == Id)
                      select a)
                      .FirstOrDefault();
            if (bv != null)
            {
                db.Remove(bv);
                db.SaveChanges();
                result = true;
            }
            return Json(result);
        }

        public ActionResult AddEditArticle(int Id)
        {
            List<Article> list = db.Articles.ToList();
            Article model = new Article();
            if (Id > 0)
            {
                Article bv = db.Articles.SingleOrDefault(x => x.Id == Id);
                model.A_name = bv.A_name;
                model.A_content = bv.A_content;
            }

            return PartialView("AddEditArticle", model);
        }
        public IActionResult EditArticle(Article model)
        {

            List<Article> list = db.Articles.ToList();
            if (model.Id > 0)
            {
                Article bv = db.Articles.SingleOrDefault(x => x.Id == model.Id);

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileName(model.A_avatar_file.FileName);
                //  string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                bv.A_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                string path = Path.Combine(wwwRootPath + "/img/", fileName);
                var fileStream = new FileStream(path, FileMode.Create);
                model.A_avatar_file.CopyToAsync(fileStream);

                bv.A_name = model.A_name;

                bv.A_content = model.A_content;

                db.SaveChanges();
            }
            else
            {
                Article bv = new Article();

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileName(model.A_avatar_file.FileName);
                //  string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                bv.A_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                string path = Path.Combine(wwwRootPath + "/img/", fileName);
                var fileStream = new FileStream(path, FileMode.Create);
                model.A_avatar_file.CopyToAsync(fileStream);

                bv.A_name = model.A_name;

                bv.A_content = model.A_content;

                db.Articles.Add(bv);
                db.SaveChanges();
            }
            ViewBag.Articles = db.Articles.ToList();

            return RedirectToAction("Index");
        }
    }
}
