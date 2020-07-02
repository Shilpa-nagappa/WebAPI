using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppSample.Models;


namespace WebAppSample.Controllers
{
    public class EmployeeController : ApiController
    {
        IList<Employee> employees = new List<Employee>()
        {
            new Employee()
                {
                    EmployeeId = 1, EmployeeName = "Shilpa", Address = "Bangalore", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 2, EmployeeName = "Karthik", Address = "Bangalore", Department = "HR"
                },
                new Employee()
                {
                    EmployeeId = 3, EmployeeName = "Pooja", Address = "Chennai", Department = "IT"
                },
                new Employee()
                {
                    EmployeeId = 4, EmployeeName = "Sushil", Address = "Noida", Department = "Sales"
                },
                new Employee()
                {
                    EmployeeId = 5, EmployeeName = "Anup", Address = "Bangalore", Department = "HR"
                },
        };

        // Using Ienumerable 
        public IEnumerable<Employee> Get()
        {
            return employees;

        }      
              
        public Employee GetEmployeeDetails(int id)
        {
            //I am returning an a single employee detail using Linq firstordefault
            var employee = employees.FirstOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return employee;
        }

    }
}
