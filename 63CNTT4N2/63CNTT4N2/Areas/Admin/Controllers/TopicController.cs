using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    public class TopicController : Controller
    {
        TopicsDAO topicsDAO = new TopicsDAO();
        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/Index
        public ActionResult Index()
        {
            return View(topicsDAO.getList("Index"));
        }

        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topics topics = topicsDAO.getRow(id);
            if (topics == null)
            {
                return HttpNotFound();
            }
            return View(topics);
        }

        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.CatList = new SelectList(topicsDAO.getList("Index"), "Id", "Name");
            ViewBag.OrderList = new SelectList(topicsDAO.getList("Index"), "Order", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Topics topics)
        {
            if (ModelState.IsValid)
            {
                //xu ly tu dong cho cac truong sau:
                //-----CreateAt
                topics.CreateAt = DateTime.Now;
                //-----CreateBy
                topics.CreateBy = Convert.ToInt32(Session["UserID"]);
                //slug
                topics.Slug = XString.Str_Slug(topics.Name);
                //ParentID
                if (topics.ParentId == null)
                {
                    topics.ParentId = 0;
                }
                //Order
                if (topics.Order == null)
                {
                    topics.Order = 1;
                }
                else
                {
                    topics.Order += 1;
                }
                //UpdateAt
                topics.UpdatAt = DateTime.Now;
                //UpdateBy
                topics.UpdateBy = Convert.ToInt32(Session["UserID"]);

                topicsDAO.Insert(topics);
                //hien thi thong bao thanh cong
                TempData["message"] = new XMessage("success", "Tạo mới loại sản phẩm thành công");

                return RedirectToAction("Index");
            }
            ViewBag.CatList = new SelectList(topicsDAO.getList("Index"), "Id", "Name");
            ViewBag.OrderList = new SelectList(topicsDAO.getList("Index"), "Order", "Name");

            return View(topics);
        }

        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.CatList = new SelectList(topicsDAO.getList("Index"), "Id", "Name");
            ViewBag.OrderList = new SelectList(topicsDAO.getList("Index"), "Order", "Name");
            if (id == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }
            Topics topics = topicsDAO.getRow(id);
            if (topics == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
                //return HttpNotFound();
            }
            return View(topics);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Topics topics)
        {
            if (ModelState.IsValid)
            {
                //xu ly tu dong cho cac truong sau:
                //slug
                topics.Slug = XString.Str_Slug(topics.Name);
                //ParentID
                if (topics.ParentId == null)
                {
                    topics.ParentId = 0;
                }
                //Order
                if (topics.Order == null)
                {
                    topics.Order = 1;
                }
                else
                {
                    topics.Order += 1;
                }
                //UpdateAt
                topics.UpdatAt = DateTime.Now;
                //UpdateBy
                topics.UpdateBy = Convert.ToInt32(Session["UserID"]);
                //cap nhat DB
                topicsDAO.Update(topics);
                //hien thi thong bao thanh cong
                TempData["message"] = new XMessage("success", "Cập nhật thông tin thành công");
                return RedirectToAction("Index");
            }
            ViewBag.CatList = new SelectList(topicsDAO.getList("Index"), "Id", "Name");
            ViewBag.OrderList = new SelectList(topicsDAO.getList("Index"), "Order", "Name");
            return View(topics);
        }

        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);//quay lai bao loi
                TempData["message"] = new XMessage("danger", "Xoa mau tin  thất bại");
                return RedirectToAction("Trash");
            }
            Topics topics = topicsDAO.getRow(id);
            if (topics == null)
            {
                TempData["message"] = new XMessage("danger", "Xoa mau tin  thất bại");
                return RedirectToAction("Trash");
            }
            return View(topics);// khac null thi tra ve danh sch du lieu
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topics topics = topicsDAO.getRow(id);
            // tim thay mau tin thi tien hanh xoa
            topicsDAO.Delete(topics);
            // hien thi thong bao
            TempData["message"] = new XMessage("danger", "Xoa mau tin thanh cong");
            return RedirectToAction("Trash");
        }

        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/Status/5
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            Topics topics  = topicsDAO.getRow(id);
            if (topics == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //cap nhat trang thai
            topics.Status = (topics.Status == 1) ? 2 : 1;
            //cap nhạt Update At
            topics.UpdatAt = DateTime.Now;
            //cap nhat Update By
            topics.UpdateBy = Convert.ToInt32(Session["UserID"]);
            //Update DB
            topicsDAO.Update(topics);
            //hien thi thong bao
            TempData["message"] = new XMessage("success", "Cập nhật trạng thái thành công");
            //tro ve trang Index
            return RedirectToAction("Index");
        }
        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/DelTrash/5
        public ActionResult DelTrash(int? id)
        {
            if (id == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            Topics topics = topicsDAO.getRow(id);
            if (topics == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //cap nhat trang thai
            topics.Status = 0;
            //cap nhạt Update At
            topics.UpdatAt = DateTime.Now;
            //cap nhat Update By
            topics.UpdateBy = Convert.ToInt32(Session["UserID"]);
            //Update DB
            topicsDAO.Update(topics);
            //hien thi thong bao
            TempData["message"] = new XMessage("success", "Xóa mẩu tin thành công");
            //tro ve trang Index
            return RedirectToAction("Index");
        }

        ////////////////////////////////////////////////////////////////////
        // GET: Admin/Category/Trash = luc thung rac
        public ActionResult Trash()
        {
            return View(topicsDAO.getList("Trash"));
        }


        //undu
        public ActionResult Undo(int? id)
        {
            if (id == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Phuc hoi mau tin that bai ");
                return RedirectToAction("Index");
            }
            Topics topics = topicsDAO.getRow(id);
            if (topics == null)
            {
                //hien thi thong bao
                TempData["message"] = new XMessage("danger", "Phuc hoi mau tin that bai");
                return RedirectToAction("Index");
            }
            //cap nhat trang thai status =2
            topics.Status = 2;
            //cap nhạt Update At
            topics.UpdatAt = DateTime.Now;
            //cap nhat Update By
            topics.UpdateBy = Convert.ToInt32(Session["UserID"]);
            //Update DB
            topicsDAO.Update (topics);
            //hien thi thong bao
            TempData["message"] = new XMessage("success", "Phuc hoi mau tin thành công");
            //tro ve trang Index
            return RedirectToAction("Trash");// o lai thung rac de tiep tuc phuc hoi
        }
    }
}
