using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using System.IO;
using System.IO.Compression;
using System.Data.Entity.Validation;
using System.Web.Helpers;
using System.Web.UI;
using FileLoader.Models;
using Microsoft.AspNet.Identity;

namespace FileLoader.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(List<HttpPostedFileBase> files)
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            var region = db.Regions.Find(currentUser.RegionId);
            var area = db.Areas.Find(currentUser.AreaId);
            var path = "";
            foreach (var item in files)
            {
                if (item != null)
                {
                    if (item.ContentLength > 100000000)
                    {
                        ViewBag.SizeOverflow = true;
                        return View();
                    }
                    if (item.ContentLength > 3000)
                    {
                        if (Path.GetExtension(item.FileName).ToLower() == ".rar"
                            || Path.GetExtension(item.FileName).ToLower() == ".zip"
                            || Path.GetExtension(item.FileName).ToLower() == ".doc"
                            || Path.GetExtension(item.FileName).ToLower() == ".docx"
                            || Path.GetExtension(item.FileName).ToLower() == ".xls"
                            || Path.GetExtension(item.FileName).ToLower() == ".xlsx"
                            || Path.GetExtension(item.FileName).ToLower() == ".arj")
                        {
                            if (!Directory.Exists(Server.MapPath("~/files/" + region.Name + "/" + area.Name)))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/files/" + region.Name + "/" + area.Name));
                            }
                            path = Path.Combine(Server.MapPath("~/files/" + region.Name + "/" + area.Name), item.FileName);
                            item.SaveAs(path);
                            ViewBag.UploadSuccess = true;
                        }
                        ViewBag.CorrectExtension = true;
                    }

                }
            }
            return View();
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult About(List<HttpPostedFileBase> files)
        {
            var currentUser = db.Users.Find(User.Identity.GetUserId());
            var region = db.Regions.Find(currentUser.RegionId);
            var area = db.Areas.Find(currentUser.AreaId);
            var path = "";
            foreach (var item in files)
            {
                if (item != null)
                {
                    if (item.ContentLength > 100000000)
                    {
                        ViewBag.SizeOverflow = true;
                        return View();
                    }
                    if (item.ContentLength > 0)
                    {
                        if (Path.GetExtension(item.FileName).ToLower() == ".rar"
                            || Path.GetExtension(item.FileName).ToLower() == ".zip"
                            || Path.GetExtension(item.FileName).ToLower() == ".doc"
                            || Path.GetExtension(item.FileName).ToLower() == ".docx"
                            || Path.GetExtension(item.FileName).ToLower() == ".xls"
                            || Path.GetExtension(item.FileName).ToLower() == ".xlsx"
                            || Path.GetExtension(item.FileName).ToLower() == ".arj")
                        {
                            if (!Directory.Exists(Server.MapPath("~/files/" + region.Name + "/" + area.Name)))
                            {
                                Directory.CreateDirectory(Server.MapPath("~/files/" + region.Name + "/" + area.Name));
                            }
                            path = Path.Combine(Server.MapPath("~/files/" + region.Name + "/" + area.Name), item.FileName);
                            item.SaveAs(path);
                            ViewBag.UploadSuccess = true;
                        }
                        ViewBag.CorrectExtension = true;
                    }

                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            string path = Server.MapPath("~/files");
            string zipPath = Server.MapPath("~/Extract/base.zip");
            if (System.IO.File.Exists(zipPath))
            {
                System.IO.File.Delete(zipPath);
            }
            ZipFile.CreateFromDirectory(path, zipPath, CompressionLevel.Fastest, true);
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Contact(bool response)
        {
            if (response)
            {
                string path = Server.MapPath("~/files");
                System.IO.DirectoryInfo di = new DirectoryInfo(path);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
            }
            return View();
        }

        
    }
}