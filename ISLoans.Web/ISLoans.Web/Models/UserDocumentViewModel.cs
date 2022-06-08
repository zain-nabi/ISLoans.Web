using System;
using System.Collections.Generic;

namespace ISLoans.Web.Models
{
    public class UserDocumentViewModel
    {
        public int documentRepositoryID { get; set; }
        public string imgName { get; set; }
        public byte[] imgData { get; set; }
        public string imgContentType { get; set; }
        public int imgLength { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string IDNumber { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class DocumentViewModel
    {
        public string IDNumber { get; set; }
        public List<UserDocumentViewModel> UserDocumentList { get; set; }
    }
}
