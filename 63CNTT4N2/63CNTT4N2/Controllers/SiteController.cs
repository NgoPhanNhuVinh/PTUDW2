﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;//tao ra csdl
namespace _63CNTT4N2.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            
            MyDBContext db = new MyDBContext();//tao moi database
            int sodong = db.Products.Count();
            ViewBag.sodong = sodong;
            return View();
        }
    }
}