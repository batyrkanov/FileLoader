using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using System.IO;
using System.Data.Entity.Validation;
using System.Web.Helpers;
using System.Web.UI;

namespace FileLoader.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(List<HttpPostedFileBase> files)
        {

            var path = "";
            foreach (var item in files)
            {
                if (item != null)
                {
                    if (item.ContentLength > 0)
                    {
                        if (Path.GetExtension(item.FileName).ToLower() == ".rar"
                            || Path.GetExtension(item.FileName).ToLower() == ".zip"
                            || Path.GetExtension(item.FileName).ToLower() == ".docx"
                            || Path.GetExtension(item.FileName).ToLower() == ".xls"
                            || Path.GetExtension(item.FileName).ToLower() == ".xlsx")
                        {
                            path = Path.Combine(Server.MapPath("~/files"), item.FileName);
                            item.SaveAs(path);
                            ViewBag.UploadSuccess = true;
                        }
                        ViewBag.CorrectExtension = true;
                    }
                    if (item.ContentLength > 100000000)
                    {
                        ViewBag.SizeOverflow = true;
                    }
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}