﻿using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DAVESWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/Homepage/Home/Index");
        }
        public ActionResult selectCount()
        {
            var us = this.Session["USER"] as User;
            if (us == null)
            {
                var info1 = new
                {
                    count = "0",
                    Area = "请登录"
                };
                return Json(info1, JsonRequestBehavior.AllowGet);
            }
            var ussite = new UserSiteManager().GetEntitysWhereAsNoTracking(x => x.UserId == us.Id & x.SitePre == 1).FirstOrDefault();
            var area = ussite.QuXian.Shi.Sheng.name + ussite.QuXian.Shi.Name + ussite.QuXian.Name + ussite.SiteDetail;
            var sp = new ShopCarManager().GetEntitysWhere(x => x.UserId == us.Id);
            var info = new {
                count = sp.Count,
                Area=area
            };
            return Json(info, JsonRequestBehavior.AllowGet);
        }
    }
}