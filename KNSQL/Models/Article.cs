using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNSQL.Models
{
    [Table("Article")]
    public class Article
    {
        [Key]
        public string ArticleID { get; set; }
        public string ArticleName { get; set; }
        [AllowHtml]
        public string ArticleAdress { get; set; }
    }

}