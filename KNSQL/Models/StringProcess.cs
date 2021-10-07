using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Security.Cryptography;

namespace KNSQL.Models
{
    public class StringProcess
    {
        public string GenerateKey(string id)
        {
            string strkey = "";
            string numPart = "", strPart = "", strPhanso = "";
            numPart = Regex.Match(id, @"\d+").Value;
            strPart = Regex.Match(id, @"\D+").Value;
            int Phanso = (Convert.ToInt32(numPart) + 1);
            for (int i = 0; i < numPart.Length - Phanso.ToString().Length; i++)
            {
                strPhanso += "0";
            }
            strPhanso += Phanso;
            strkey = strPart + strPhanso;
            return strkey;
        }
        public string GetMD5(string strInput)
        {
            string str_md5 = "";
            byte[] arrOut = System.Text.Encoding.UTF8.GetBytes(strInput);
            MD5CryptoServiceProvider my_md5 = new MD5CryptoServiceProvider();
            arrOut = my_md5.ComputeHash(arrOut);
            foreach (byte b in arrOut)
            {
                str_md5 += b.ToString("X2");
            }
            return str_md5;
        }
    }
}
