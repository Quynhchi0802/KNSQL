using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
    public class NhanVien : Nguoi
    {
        public string DiaChi { get; set; }
        public string CongTy { get; set; }
    }
}