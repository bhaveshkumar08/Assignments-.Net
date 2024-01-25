using Microsoft.AspNetCore.Mvc;
using firstMVCPoject.Models;

namespace firstMVCPoject.Controllers{
    public class EmployeeController : Controller{
        public EmployeeController() { 

        }

        public IActionResult ShowDetails()
        {
            List<Employee> empL = new List<Employee>();    
            Employee e = new Employee();
            e.Eid = 1;
            e.Ename = "bk";
            e.Salary = 1000;
            Employee e1 = new Employee();
            e1.Eid = 2;
            e1.Ename = "ram";
            e1.Salary = 200;
            empL.Add(e);
            empL.Add(e1);

            return View(empL);
        }
        public IActionResult GetAllEmployees()
        {
            List<Employee> empL = new List<Employee>();    
            Employee e = new Employee();
            e.Eid = 1;
            e.Ename = "bk";
            e.Salary = 1000;
            Employee e1 = new Employee();
            e1.Eid = 2;
            e1.Ename = "ram";
            e1.Salary = 200;
            empL.Add(e);
            empL.Add(e1);

            return View(empL);
        }
    }
}