using System;

namespace ISLoans.Web.Models
{
    public class DocumentRepositoryViewModel
    {
        public int DocumentRepositoryID { get; set; }
        public string ImgName { get; set; }
        public byte[] ImgData { get; set; }
        public string ImgContentType { get; set; }
        public int ImgLength { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByUserID { get; set; }
        public int? DeletedByUserID { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
