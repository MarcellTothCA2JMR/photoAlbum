using System;
using System.Collections.Generic;

#nullable disable

namespace KepRendszerezo.Models
{
    public partial class StoredPicture
    {
        public int Id { get; set; }
        public int PictureId { get; set; }
        public int FolderId { get; set; }
    }
}
