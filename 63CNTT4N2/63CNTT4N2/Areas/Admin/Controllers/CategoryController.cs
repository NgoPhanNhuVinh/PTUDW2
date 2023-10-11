using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;// do no su dung lop CategoryDAO
namespace _63CNTT4N2.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
     CategoriesDAO categoriesDAO = new CategoriesDAO();

        /// ////////////////////////////////////////////////////

        /// <returns></returns>
        // GET: Admin/Category/index
        public ActionResult Index()
        {
            return View(categoriesDAO.getList("Index"));
        }

        // GET: Admin/Category/detail
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = categoriesDAO.getRow(id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        public ActionResult Create()
        {
            //tra ve 1 danh sach, tra ve tu categoriDAO tra ve truong nhin thay, thang nao co index thi hien thi ra
            ViewBag.CatList = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");
            ViewBag.CatList = new SelectList(categoriesDAO.getList("Index"), "Order", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                //xu li tu dong cho cac truong sau
                //CREATE AT
                categories.CreateAt = DateTime.Now;
                //createby
                categories.CreateBy = Convert.ToInt32(Session["UserID"]);

              categoriesDAO.Insert(categories);
                return RedirectToAction("Index");
            }

            return View(categories);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories = categoriesDAO.getRow(id);//tim thay mau tin dua vao id
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                categoriesDAO.Update(categories);
                //db.Entry(categories).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categories categories =categoriesDAO.getRow(id);//xem thu co mau tin ton tai ko
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categories categories = categoriesDAO.getRow(id);
            categoriesDAO.Delete(categories);
           
            return RedirectToAction("Index");
        }

    }
}


//

//        // GET: Admin/Category/Create
//      

//        // POST: Admin/Category/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
// 

//        // GET: Admin/Category/Edit/5
//      

//        // POST: Admin/Category/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//      

//        // GET: Admin/Category/Delete/5
//      
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
