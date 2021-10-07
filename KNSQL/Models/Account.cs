using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
	public class Account
	{
        [Key]
        [Required(ErrorMessage ="Username is a required")]
        public string Username { get; set; }
      
        [Required(ErrorMessage = "password is a required")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [StringLength(10)]
        public string RoleID { get; set; }

    }
}