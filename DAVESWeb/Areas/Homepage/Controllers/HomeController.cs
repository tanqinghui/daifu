﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace DAVESWeb.Areas.Homepage.Controllers
{
    public class HomeController : Controller
    {
        // GET: Homepage/Home
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 查询类型商品
        /// </summary>
        /// <returns></returns>
        public ActionResult selectAll()
        {
            ComTypeManager c = new ComTypeManager();
            var list = c.GetEntitysWhere(x => x.ComTypeParId == 1);
            var list1 = list.Select(x => new {
                x.Id,
                x.ComTypeName,
                x.ComTypeParId,
                x.ComTypeUrl,
                listtwo = x.ComType1.Select(y => new {
                    y.Id,
                    y.ComTypeName,
                    y.ComTypeParId,
                    y.ComTypeUrl,
                    listhree = y.ComType1.Select(z => new
                    {
                        z.Id,
                        z.ComTypeName,
                        z.ComTypeParId,
                        z.ComTypeUrl,
                        listcom = z.Com.Select(w =>new {
                            w.Id,
                            w.ComWeight,
                            w.ComName,
                            w.ComBz,
                            w.ComMoney,
                            w.ComTypeId,
                            w.ComStatic
                        })
                    })
                })
            });
            return Json(list1, JsonRequestBehavior.AllowGet);
        }

        public ActionResult selecByAll(int Id)
        {
            ComTypeManager c = new ComTypeManager();
            var list = c.GetEntitysWhere(x => x.ComTypeParId == Id);
            var list1 = list.Select(x => new {
                x.Id,
                x.ComTypeName,
                x.ComTypeParId,
                x.ComTypeUrl,

            });
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
        public ActionResult selecComAll(int Id)
        {
            ComManager c = new ComManager();
            var list = c.GetEntitysWhere(x => x.ComTypeId == Id&x.ComStatic==1);
            var list1 = list.Select(x => new {
                x.Id,
                x.ComName,
                x.ComMoney,
                x.ComBz,
                x.ComWeight
            });
            return Json(list1, JsonRequestBehavior.AllowGet);
        }
    }
}