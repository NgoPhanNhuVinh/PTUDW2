﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;

namespace _63CNTT4N2.Controllers
{
    public class ModuleController : Controller
    {
        MenusDAO menusDAO = new MenusDAO();
        // GET: Module
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MainMenu()
        {
            // hien thi menu dua vao 2 truong 1 parentid=0 va status=1
            List<Menus> list = menusDAO.getListByParentId(0);
            return View(list);// tra ve 1 list
        }
    }
}