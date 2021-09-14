using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KNSQL.Models
{
    public class NewPerson : Person
    {
        public string School { get; set; }
        public string Subject { get; set; }
    }
}