using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNSQL.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public DataTable ReadDataFormExcelFile(string filepath, bool removeRow0)
        //{
        //    string connectionString = "";
        //    string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
        //    if(fileExtention.IndexOf("xlsx") < 0)
        //    {
        //        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =" + filepath + ";Extended ProperList=Excel 8.8";
     
        //    }
        //    else
        //    {
        //        connectionString = "Provider ="Microsoft.ACE.OLEDB.12.0; Data Source = " + filepath + "; Extended ProperList = \"Excel 12.0 Xml;HDR=NO\"";
                   
        //    }    
        //    return Data;
        }
    }

