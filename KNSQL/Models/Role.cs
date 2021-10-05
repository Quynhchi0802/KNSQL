using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
    public class Role
    {
        [Key]
        [StringLenghth(10)]
        public string RoleID { get; set; }
        [StringLenghth(50)]
        public string RoleName { get; set; }
    }
}