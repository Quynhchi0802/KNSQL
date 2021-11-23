using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
    [Table("LoaiSanPhams")]
    public class LoaiSanPham
    {
        [Key]
        public string LoaiSanPhamID { get; set; }
        public string TenLoaiSanPham { get; set; }
        public ICollection<SanPham> SanPhams { get; set; }
    }
}