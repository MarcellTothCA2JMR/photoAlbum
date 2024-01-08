using Aspose.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KepRendszerezo.Models
{
    public static class ProcedureHelper
    {
        /// <summary>
        /// Gives back the locations of the folders at the database
        /// </summary>
        /// <returns>Sorted locations of the folders</returns>
        public static List<string> GivaBackLocation()
        {
            List<string> Locs = new List<string>();
            mydata db = new mydata();
            foreach (Folder fo in db.Folders)
            {
                if (!Locs.Contains(fo.Location))
                {
                    Locs.Add(fo.Location);
                }
            }
            Locs.Sort();
            return Locs;
        }

        /// <summary>
        /// Count the number of pictures of the folders
        /// </summary>
        /// <returns>Folder ID-s with the related number of images</returns>
        public static Dictionary<int, int> ChartDataCollector()
        {
            mydata db = new mydata();
            Dictionary<int, int> FoldersPicNumbers = new Dictionary<int, int>();
            foreach (Folder fr in db.Folders)
            {
                FoldersPicNumbers.Add(fr.Id, 0);
            }
            foreach (StoredPicture stored in db.StoredPictures)
            {
                if (FoldersPicNumbers.ContainsKey(stored.FolderId))
                {
                    FoldersPicNumbers[stored.FolderId]++;
                }
            }
            return FoldersPicNumbers;
        }

        /// <summary>
        /// Search the images with the given foldername and date
        /// </summary>
        /// <param name="fold">Folder</param>
        /// <returns>Pictures with the given foldername and date</returns>
        public static List<int> GiveBackPictureIdsFromFolderNameAndDate(ref Folder fold)
        {
            mydata md = new mydata();
            foreach (Folder f in md.Folders)
            {
                if (f.Name == fold.Name && f.Date == fold.Date)
                {
                    fold.Id = f.Id;
                    break;
                }
            }

            List<int> picIds = new List<int>();
            foreach (StoredPicture stp in md.StoredPictures)
            {
                if (stp.FolderId == fold.Id)
                {
                    picIds.Add(stp.PictureId);
                }
            }

            return picIds;
        }

        /// <summary>
        /// Compress to a ZIP archive from the given pictures
        /// </summary>
        /// <param name="archiveName">Name of the archive</param>
        /// <param name="picIds">List of picure ID-s</param>
        public static void ZiperProc(string archiveName, List<int> picIds)
        {
            mydata md = new mydata();
            using (FileStream zipFile = System.IO.File.Open(archiveName, FileMode.Create))
            {
                using (var archive = new Archive())
                {
                    foreach (Picture ptr in md.Pictures)
                    {
                        if (picIds.Contains(ptr.Id))
                        {
                            archive.CreateEntry(ptr.Name, ptr.Path);
                        }
                    }
                    archive.Save(zipFile);
                }
            }
        }

        /// <summary>
        /// Delete a folder with all pictures in it
        /// </summary>
        /// <param name="identifier">ID of the folder</param>
        public static void DeleteFromAllTables(int identifier)
        {
            mydata md = new mydata();

            foreach (Folder fldr in md.Folders)
            {
                if (fldr.Id == identifier)
                {
                    md.Folders.Remove(fldr);
                    break;
                }
            }

            List<int> ImgIdsToDel = new List<int>();

            foreach (StoredPicture stdp in md.StoredPictures)
            {
                if (stdp.FolderId == identifier)
                {
                    ImgIdsToDel.Add(stdp.PictureId);
                    md.StoredPictures.Remove(stdp);
                }
            }

            foreach (Picture p in md.Pictures)
            {
                if (ImgIdsToDel.Contains(p.Id))
                {
                    md.Pictures.Remove(p);
                }
            }

            md.SaveChanges();
        }
    }
}
