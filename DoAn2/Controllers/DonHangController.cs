using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DoAn2.Models;

namespace DoAn2.Controllers
{
    public class DonHangController : Controller
    {
        private DataContext db = new DataContext();

        // GET: DonHangController
        public ActionResult Index()
        {
            ViewBag.Transactions = db.Transactions.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Transaction model)
        {
            ViewBag.Transactions = db.Transactions.ToList();
            if (model.Id > 0)
            {
                Transaction dh = db.Transactions.SingleOrDefault(x => x.Id == model.Id);
                dh.Tr_name = model.Tr_name;
                db.SaveChanges();
            }

            return View(model);
        }

        public ActionResult ViewOrders(int Id)
        {
            //Order model = new Order();

            var query = from t in db.Transactions
                        join o in db.Orders on Id equals o.Or_transaction_id
                        join p in db.Products on o.Or_product_id equals p.Id
                        where t.Id == Id
                         select new Order
                         {
                             Id = o.Id,
                             Or_transaction_id = t.Id,
                             Or_product_name = p.Pro_name,
                             Or_qty = o.Or_qty,
                             Or_price = o.Or_price,
                         };

            var query1 = from t in db.Transactions
                         where t.Id == Id
                         select t.Tr_total;

            ViewBag.Orders = query.ToList();
            ViewBag.totalPrice = query1;

            return PartialView("ViewOrders");
        }

        public IActionResult Duyet(Transaction model)
        {

            if (model.Id > 0)
            {
                Transaction hd = db.Transactions.SingleOrDefault(x => x.Id == model.Id);
                hd.Tr_status = true;
                db.SaveChanges();
            }
            ViewBag.Hoadon = db.Transactions.ToList();
            return RedirectToAction("Index");
        }

        public ActionResult EditHoadon(int ID)
        {
            Transaction model = new Transaction();
            if (ID > 0)
            {
                Transaction hd = db.Transactions.SingleOrDefault(x => x.Id == ID);
                model.Id = hd.Id;
                model.Tr_name = hd.Tr_name;
                model.Tr_phone = hd.Tr_phone;
                model.Tr_status = hd.Tr_status;
                model.Tr_total = hd.Tr_total;
                model.Tr_address = hd.Tr_address;
                model.Tr_note = hd.Tr_note;
            }
            return PartialView("EditHoadon", model);
        }

    }
}
