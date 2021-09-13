using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [Required(ErrorMessage ="ID không được để trống")]
        
        public string StudentID { get; set; }
        [Required(ErrorMessage ="Tên không được để trống")]
        [MinLength(4)]
        public string StudentName { get; set; }
        [Required(ErrorMessage ="không được để trống")]
        public string Address { get; set; }
    }
}