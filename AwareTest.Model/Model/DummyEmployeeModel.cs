using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwareTest.Model.Model
{
    public class DummyEmployeeModel
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public double employee_age { get; set; }
        public string profile_image { get; set; }
        
    }
    public class ApiResponseModel
    {
        public string status { get; set; }
        public List<DummyEmployeeModel> data { get; set; }
        public string message { get; set; }
    }
}
