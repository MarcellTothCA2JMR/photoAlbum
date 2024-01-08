using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KepRendszerezo.Models
{
    public class FotoModel
    {
        public string[] FPath { get; set; }

        public FotoModel(string NameOfPictures)
        {
            string[] fNames = NameOfPictures.Split(',');
            string[] fPaths = NameOfPictures.Split(',');

            DirectoryInfo di = new DirectoryInfo(@"C:\temp\Images\");
            for (int i = 0; i < fNames.Length; i++)
            {
                foreach (FileInfo fi in di.GetFiles())
                {
                    if (fi.Name == fNames[i])
                    {
                        fPaths[i] = fi.FullName;
                        break;
                    }
                }
            }
            FPath = fPaths;
        }
    }
}
