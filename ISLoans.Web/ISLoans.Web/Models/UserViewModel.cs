using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISLoans.Web.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        public int? Age { get; set; }
        [Required]
        public int? DOB { get; set; }
        [Required]
        public string idNumber { get; set; }
        public string IDNumberError { get; set; }
        public string IDNumberUniqueKey { get; set; }
    }

    public class UserViewModel
    {
        public string IDNumber { get; set; }
        public string IDNumberError { get; set; }
        public Users UserModel { get; set; }
    }
}
