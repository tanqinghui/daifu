﻿using System.Web.Mvc;

namespace DAVESWeb.Areas.Record
{
    public class RecordAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Record";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Record_default",
                "Record/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}