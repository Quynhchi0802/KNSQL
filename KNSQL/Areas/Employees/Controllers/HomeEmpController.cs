using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KNSQL.Areas.Employees.Controllers
{
    public class HomeEmpController : Controller
    {
        // GET: Employees/HomeEmp
        [Authorize(Roles = "NV")]
        public ActionResult Index()
        {
            return View();
        }
    }
}