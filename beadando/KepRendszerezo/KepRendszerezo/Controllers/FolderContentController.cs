using KepRendszerezo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KepRendszerezo.Controllers
{
    public class FolderContentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Display(int azon)
        {
            if(HttpContext.Session.GetString("DisplayPicSize") == null)
            {
                HttpContext.Session.SetString("DisplayPicSize", "200");
            }
            ViewBag.PictSize = int.Parse(HttpContext.Session.GetString("DisplayPicSize"));

            HttpContext.Session.SetString("ModFolderId", azon.ToString());

            mydata md = new mydata();
            List<int> ids = new List<int>();
            foreach (StoredPicture stp in md.StoredPictures)
            {
                if (stp.FolderId == azon)
                {
                    ids.Add(stp.PictureId);
                }
            }

            ViewBag.Ids = ids;
            ViewBag.Images = md.Pictures;
            ViewBag.Fldrs = md.Folders;
            ViewBag.FdrID = azon;
            return View();
        }

        public IActionResult Modify(int azon)
        {
            mydata md = new mydata();
            foreach (Folder fldr in md.Folders)
            {
                if (fldr.Id == azon)
                {
                    ViewBag.FldrToMod = fldr;
                    HttpContext.Session.SetString("ModFolderId", azon.ToString());
                    break;
                }
            }
            return View();
        }
        

        [HttpPost]
        public IActionResult ModifyFolder(Folder fold)
        {
            fold.Colour = HttpContext.Request.Form["fdrCol"];
            fold.Id = int.Parse(HttpContext.Session.GetString("ModFolderId"));
            if (fold.Date.Year < 1754)
            {
                fold.Date = DateTime.Parse("9000/1/1");
            }

            mydata md = new mydata();
            foreach (Folder fldr in md.Folders)
            {
                if (fldr.Id == fold.Id)
                {
                    fldr.Name = fold.Name;
                    fldr.Date = fold.Date;
                    fldr.People = fold.People;
                    fldr.Location = fold.Location;
                    fldr.Colour = fold.Colour;
                    break;
                }
            }
            md.SaveChanges();

            return View();
        }


        public IActionResult Delete(int azon)
        {
            ProcedureHelper.DeleteFromAllTables(azon);
            return View();
        }



        public ActionResult Diag(string path)
        {
            string pathToUse = path;
            Bitmap b = new Bitmap(pathToUse);
            Graphics g = Graphics.FromImage(b);
            
            MemoryStream memoryStream = new MemoryStream();
            b.Save(memoryStream, ImageFormat.Jpeg);

            memoryStream.Seek(0, SeekOrigin.Begin);
            return File(memoryStream, "image/jpg");
        }


        [HttpPost]
        public IActionResult AddNewPicture(Picture pic)
        {
            string fName = HttpContext.Request.Form["uploadFile"];

            string[] fNames = fName.Split(',');

            FotoModel fm = new FotoModel(fName);
            string[] fullFilePaths = fm.FPath;


            mydata md = new mydata();
            for (int i = 0; i < fNames.Length; i++)
            {
                Picture PicToAdd = new Picture();
                PicToAdd.Name = fNames[i];
                PicToAdd.Path = fullFilePaths[i];
                md.Pictures.Add(PicToAdd);
            }
            md.SaveChanges();


            mydata secondMd = new mydata();
            for (int i = 0; i < fNames.Length; i++)
            {
                foreach (Picture pict in secondMd.Pictures)
                {
                    if (pict.Name == fNames[i])
                    {
                        StoredPicture strdNewPic = new StoredPicture();
                        strdNewPic.PictureId = pict.Id;
                        strdNewPic.FolderId = int.Parse(HttpContext.Session.GetString("ModFolderId"));
                        secondMd.StoredPictures.Add(strdNewPic);
                        break;
                    }
                }
            }
            secondMd.SaveChanges();

            ViewBag.FID = int.Parse(HttpContext.Session.GetString("ModFolderId"));
            return View();
        }

        [HttpPost]
        public IActionResult ChangePictureSize()
        {
            string radioVal = Request.Form["radioS"];
            HttpContext.Session.SetString("DisplayPicSize", radioVal);

            ViewBag.FID = int.Parse(HttpContext.Session.GetString("ModFolderId"));
            return View();
        }
    }
}
