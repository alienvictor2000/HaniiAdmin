using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DoAn2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;
using System.Text;

namespace DoAn2.Controllers
{
    public class SanPhamController : Controller
    {
       
        private readonly DataContext db = new DataContext();
        private readonly IWebHostEnvironment _hostEnvironment;
        public SanPhamController(IWebHostEnvironment iweb)
        {
            _hostEnvironment = iweb;
            
        }

        public static string ToUrlSlug(string value)
        {

            //First to lower case
            value = value.ToLowerInvariant();

            //Remove all accents
            var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            value = Encoding.ASCII.GetString(bytes);

            //Replace spaces
            value = Regex.Replace(value, @"\s", "-", RegexOptions.Compiled);

            //Remove invalid chars
            value = Regex.Replace(value, @"[^a-z0-9\s-_]", "", RegexOptions.Compiled);

            //Trim dashes from end
            value = value.Trim('-', '_');

            //Replace double occurences of - or _
            value = Regex.Replace(value, @"([-_]){2,}", "$1", RegexOptions.Compiled);

            return value;
        }

        public IActionResult Index()
        {
            ViewBag.Products = db.Products.ToList();
            return View();
        }
       
        [HttpPost]
        public IActionResult Index(Product model)
        {
            try
            {
                List<Category> list = db.Categories.ToList();
                ViewBag.CategoryList = new SelectList(list, "Id", "C_name");
                if (model.Id > 0)
                {
                    Product sp = db.Products.SingleOrDefault(x => x.Id == model.Id);

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(model.Pro_avatar_file.FileName);
                    //  string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                    sp.Pro_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    model.Pro_avatar_file.CopyToAsync(fileStream);

                    sp.Pro_name = model.Pro_name;
                    sp.Pro_price = model.Pro_price;
                    sp.Pro_description = model.Pro_description;
                    sp.Pro_slug = ToUrlSlug(model.Pro_name);

                    sp.Pro_category_id = model.Pro_category_id;
                    db.SaveChanges();
                }
                else
                {
                    Product sp = new Product();

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(model.Pro_avatar_file.FileName);
                    //  string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                    sp.Pro_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    model.Pro_avatar_file.CopyToAsync(fileStream);

                    sp.Pro_name = model.Pro_name;
                    sp.Pro_price = model.Pro_price;
                    sp.Pro_description = model.Pro_description;
                    sp.Pro_slug = ToUrlSlug(model.Pro_name);

                    sp.Pro_category_id = model.Pro_category_id;

                    db.Products.Add(sp);
                    db.SaveChanges();
                }
                ViewBag.Products = db.Products.ToList();

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

       }

        public IActionResult DeleteProduct(int Id)
        {
            bool result = false;
            var sp = (from d in db.Products
                      where (d.Id == Id)
                      select d)
                      .FirstOrDefault();
            if (sp != null)
            {
                db.Remove(sp);
                db.SaveChanges();
                result = true;
            }
            return Json(result);
        }

        public ActionResult AddEditProduct(int Id)
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.CategoryList = new SelectList(list, "Id", "C_name");
            Product model = new Product();
            if (Id > 0)
            {
                Product sp = db.Products.SingleOrDefault(x => x.Id == Id);
                model.Pro_name = sp.Pro_name;
                model.Pro_slug = ToUrlSlug(sp.Pro_name);
                model.Pro_avatar = sp.Pro_avatar;

                model.Pro_price = sp.Pro_price  ;
                model.Pro_description = sp.Pro_description;
                model.Pro_category_id = sp.Pro_category_id ;
            }
        
            return PartialView("AddEditProduct", model);
        }
        public IActionResult EditProduct(Product model)
        {
            
                List<Category> list = db.Categories.ToList();
                ViewBag.CategoryList = new SelectList(list, "Id", "C_name");
                if (model.Id > 0)
                {
                    Product sp = db.Products.SingleOrDefault(x => x.Id == model.Id);

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(model.Pro_avatar_file.FileName);
                //  string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                    sp.Pro_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    model.Pro_avatar_file.CopyToAsync(fileStream);

                    sp.Pro_name = model.Pro_name;
                    sp.Pro_description = model.Pro_description;
                    sp.Pro_slug = ToUrlSlug(model.Pro_name);

                    sp.Pro_price = model.Pro_price;
                    sp.Pro_category_id = model.Pro_category_id;
                    db.SaveChanges();
                }
                else
                {
                    Product sp = new Product();

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileName(model.Pro_avatar_file.FileName);
                    //string extension = Path.GetExtension(model.Pro_avatar_file.FileName);
                    sp.Pro_avatar = fileName; /*= fileName + DateTime.Now.ToString("yymmssfff") + extension;*/
                    string path = Path.Combine(wwwRootPath + "/img/", fileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    model.Pro_avatar_file.CopyToAsync(fileStream);

                    sp.Pro_name = model.Pro_name;
                    sp.Pro_description = model.Pro_description;
                    sp.Pro_slug = ToUrlSlug(model.Pro_name);

                    sp.Pro_price = model.Pro_price;
                    sp.Pro_category_id = model.Pro_category_id;
                    db.Products.Add(sp);
                    db.SaveChanges();
                }
                ViewBag.Products = db.Products.ToList();

                return RedirectToAction("Index");
            }

        }
    }

