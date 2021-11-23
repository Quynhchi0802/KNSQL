using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
    [Table("Nguois")]
    public class Nguoi
    {
        [Key]
        public string CCCD { get; set; }
        public string HoTen { get; set; }
    }
}