using Company.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.WebApi.Models
{
    public class DepartmentModel
    {
        public int departmentNo { get; set; }
        public string departmentName { get; set; }
        public string departmentLocation { get; set; }
       
    }
}