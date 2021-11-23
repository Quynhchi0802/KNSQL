using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
    [Table("SanPhams")]
    public class SanPham
    {
        [Key]
        public string SanPhamID { get; set; }
        public string TenSanPham { get; set; }
        public string LoaiSanPhamID { get; set; }
        public LoaiSanPham LoaiSanPham { get; set; }

    }
}