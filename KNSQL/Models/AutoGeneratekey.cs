using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace KNSQL.Models
{
    public class AutoGeneratekey
    {
        public string GeneraKey(string id)
        {
            string strkey = "";
            string numPart = "", strPart = "", strPhanSo = "";
            //tách phần số
            numPart = Regex.Match(id, @"\d+").Value;
            int phanso = (Convert.ToInt32(numPart) + 1);
            for (int i = 0; i < numPart.Length-1;i++)
            {
                strPhanSo += "0";
               
            }
            strPhanSo += phanso;
            //tách phần chữ 
            strkey = strPart + strPhanSo;
            return strkey;
        }

       
    }
}