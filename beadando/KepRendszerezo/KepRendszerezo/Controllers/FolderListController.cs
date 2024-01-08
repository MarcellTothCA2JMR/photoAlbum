using Aspose.Zip;
using KepRendszerezo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KepRendszerezo.Controllers
{
    public class FolderListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Listing(Folder fldr)
        {
            fldr.Location = HttpContext.Request.Form["FilterLoc"];

            bool IsNamesEmpty = false;
            if(fldr.People == null)
            {
                fldr.People = "";
                IsNamesEmpty = true;
            }
            string[] persons = fldr.People.Split(", ");
            ViewBag.EmptyNames = IsNamesEmpty;

            ViewBag.FilterLocat = fldr.Location;
            ViewBag.FilterPers = persons;
            mydata md = new mydata();
            ViewBag.Adatb = md.Folders;
            return View();
            
        }

        [HttpPost]
        public IActionResult AddNewFolder(Folder fold)
        {
            fold.Colour = HttpContext.Request.Form["szin"];
            if(fold.Date.Year<1754)
            {
                fold.Date = DateTime.Parse("9000/1/1");
            }
            mydata md = new mydata();
            md.Folders.Add(fold);
            md.SaveChanges();
            
            return View();
        }


        [HttpPost]
        public IActionResult Ziping(Folder fold)
        {
            string Infos = HttpContext.Request.Form["ZipFold"];
            fold.Name = Infos.Split(" - ")[0];
            fold.Date = DateTime.Parse(Infos.Split(" - ")[1]);
            string archiveName = fold.Name + "__" + fold.Date.Year + "_" + fold.Date.Month + "_" + fold.Date.Day + ".zip";

            List<int> picIds = ProcedureHelper.GiveBackPictureIdsFromFolderNameAndDate(ref fold);

            ProcedureHelper.ZiperProc(archiveName, picIds);

            return View();
        }
    }
}
