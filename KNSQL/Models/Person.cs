using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNSQL.Models
{
    public class Person
    {
        public static object ChooseImage { get; internal set; }
        [Key]
        public string PersonID { get; set; }
        [AllowHtml]
        public string PersonName { get; set; }
    }
}