using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _63CNTT4N2.Library;
using MyClass.DAO;
using MyClass.Model;
using UDW.Library;

namespace _63CNTT4N2.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductsDAO productsDAO = new ProductsDAO();
        CategoriesDAO categoriesDAO = new CategoriesDAO();
        //lay tu nha cung cap
        SuppliersDAO suppliersDAO = new SuppliersDAO();

        // GET: Admin/Products
        public ActionResult Index()
        {
            return View(productsDAO.getList("Index"));
        }




        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Không tìm thấy san pham");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                TempData["message"] = new XMessage("danger", "Không tìm thấy san pham");
                return RedirectToAction("Index");
            }
            return View(products);
        }





        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            //co 2 danh sach lua chon, tra ve 2 danh sach
            ViewBag.ListCatID = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");//lay tu category
            ViewBag.ListSupID = new SelectList(suppliersDAO.getList("Index"), "Id", "Name");// cua supplier 
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Products products)
        {
            if (ModelState.IsValid)
            {
                //xu ly tu dong mot so truong
                //-----CreateAt
                products.CreateAt = DateTime.Now;
                //-----CreateBy
                products.CreateBy = Convert.ToInt32(Session["UserID"]);
                //slug
                products.Slug = XString.Str_Slug(products.Name);
                //


                products.UpdateAt = DateTime.Now;
                //-----CreateBy
                products.UpdateBy = Convert.ToInt32(Session["UserID"]);
                // xu li cho 1 hinh anh
                var img = Request.Files["img"];//lay thong tin file
                if (img.ContentLength != 0)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string slug = products.Slug;
                        //ten file = Slug + phan mo rong cua tap tin
                        string imgName = slug + "_" + products.Id + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        products.Image = imgName;
                        //upload hinh anh vao folder product
                        string PathDir = "~/Public/img/product/";
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);
                    }
                }//ket thuc phan upload hinh anh


                //chen them dong du lieu vao database

                //xu li tu dong cho mot so truong
                productsDAO.Insert(products);

                // thong bao them moi thanh cong
                TempData["message"] = new XMessage("danger", "them moi san pham thanh cong");
                return RedirectToAction("Index");
            }
            // trg hop nhan nut luu thi tra ve 2 truong nay
            ViewBag.ListCatID = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");//lay tu category
            ViewBag.ListSupID = new SelectList(suppliersDAO.getList("Index"), "Id", "Name");// cua supplier 

            return View(products);
        }






        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Không tìm thấy san pham");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                TempData["message"] = new XMessage("danger", "Không tìm thấy san pham");
                return RedirectToAction("Index");
            }
            ViewBag.ListCatID = new SelectList(categoriesDAO.getList("Index"), "Id", "Name");//lay tu category
            ViewBag.ListSupID = new SelectList(suppliersDAO.getList("Index"), "Id", "Name");// cua supplier 
            return View(products);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Products products)
        {
            if (ModelState.IsValid)
            {
                //xu li tu dong mot so truong c
                products.Slug = XString.Str_Slug(products.Name);
                //


                products.UpdateAt = DateTime.Now;
                //-----CreateBy
                products.UpdateBy = Convert.ToInt32(Session["UserID"]);

                //xu li hinh anh
                var img = Request.Files["img"];//lay thong tin file
                string PathDir = "~/Public/img/product/";
                if (img.ContentLength != 0 && products.Image != null)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string DelPath = Path.Combine(Server.MapPath(PathDir), products.Image);
                        System.IO.File.Delete(DelPath);
                    }
                }
                //cap nhap mau tin 
                productsDAO.Update(products);
                return RedirectToAction("Index");
            }
            return View(products);
        }






        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["message"] = new XMessage("danger", "Không tìm thấy san pham");
               
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                TempData["message"] = new XMessage("danger", "Không tìm thấy san pham");
               
            }
            return View(products);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = productsDAO.getRow(id);
            //tim va xoa anh cua nha cung cap
            if (productsDAO.Delete(products) == 1)
            {
                string PathDir = "~/Public/img/product";
                if (products.Image != null)
                {
                    string DelPath = Path.Combine(Server.MapPath(PathDir), products.Image);
                    System.IO.File.Delete(DelPath);
                }//ket thuc phan upload hinh anh
            }


            //hien thi thong bao thanh cong
            TempData["message"] = new XMessage("success", "Xoa san pham thành công");
            return RedirectToAction("Trash");
        }




        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //cap nhat trang thai
            products.Status = (products.Status == 1) ? 2 : 1;
            //cap nhạt Update At
            products.UpdateAt = DateTime.Now;
            //cap nhat Update By
            products.UpdateBy = Convert.ToInt32(Session["UserID"]);
            //Update DB
            productsDAO.Update(products);
            //hien thi thong bao
            TempData["message"] = new XMessage("success", "Cập nhật trạng thái thành công");
            //tro ve trang Index
            return RedirectToAction("Index");
        }




        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier/DelTrash/5
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //cap nhat trang thai
            products.Status = 0;
            //cap nhạt Update At
            products.UpdateAt = DateTime.Now;
            //cap nhat Update By
            products.UpdateBy = Convert.ToInt32(Session["UserID"]);
            //Update DB
            productsDAO.Update(products);
            //hien thi thong bao
            TempData["message"] = new XMessage("success", "Xóa mẩu tin thành công");
            //tro ve trang Index
            return RedirectToAction("Index");
        }






        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier/Trash = luc thung rac
        public ActionResult Trash()
        {
            return View(suppliersDAO.getList("Trash"));
        }






        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Supplier/Undo/5
        public ActionResult Undo(int? id)
        {
            if (id == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            Products products = productsDAO.getRow(id);
            if (products == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //cap nhat trang thai status = 2
            products.Status = 2;
            //cap nhạt Update At
            products.UpdateAt = DateTime.Now;
            //cap nhat Update By
            products.UpdateBy = Convert.ToInt32(Session["UserID"]);
            //Update DB
            productsDAO.Update(products);
            //hien thi thong bao
            TempData["message"] = new XMessage("success", "Phục hồi mẩu tin thành công");
            //tro ve trang Index
            return RedirectToAction("Trash");//o lai thung rac de tiep tuc Undo
        }
    }
}
