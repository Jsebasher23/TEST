using EmployeeTest.Help;
using EmployeeTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;


namespace EmployeeTest.Controllers
{
    public class EmployeeController : Controller
    {


        // GET: Employee            
        

        [HttpGet]
        public async Task<ActionResult> Index()
        {
           
            HttpResponseMessage response = await ApiConnection.Initial().GetAsync("/api/Employees");
            string result = response.Content.ReadAsStringAsync().Result;
            var infoAsegurados = JsonConvert.DeserializeObject<List<Employee>>(result);
            CalculatedSalary(infoAsegurados,null);            
            return View("Index", infoAsegurados);            
        }
        [HttpGet]
        public async Task<ActionResult> Details( string idEmployee)
        {
           
            HttpResponseMessage response = await ApiConnection.Initial().GetAsync("/api/Employees");
            string result = response.Content.ReadAsStringAsync().Result;
            var infoAsegurados = JsonConvert.DeserializeObject<List<Employee>>(result);
            var ListFiltered = new List<Employee>();
            ListFiltered = CalculatedSalary(infoAsegurados, idEmployee);
            //var ListFilter = new List<Employee>();
            //foreach(Employee e in infoAsegurados)
            //{
            //    if( e.Id == Convert.ToInt32(idEmployee))
            //    {
            //        if( e.ContractTypeName == "MonthlySalaryEmployee")
            //        {
            //            e.Salary = e.MonthlySalary * 12;
            //        }
            //        else
            //        {
            //            e.Salary = 120 * e.HourlySalary * 12;
            //        }
            //        ListFilter.Add(e);
            //    }
            //}
            return View("Details", ListFiltered);            
                      
        }

        [HttpPost]
        public ActionResult SearchEmployee(string idEmployee)
        {
            if( idEmployee == "")
            {
                return RedirectToAction("Index","Employee");
            }

            return RedirectToAction("Details","Employee", new { idEmployee } );
            
        }

        public List<Employee> CalculatedSalary(List<Employee> Emp, string idEmployee)
        {
            var ListFilter = new List<Employee>();
          
            foreach (Employee e in Emp)
            {
                int id = string.IsNullOrEmpty(idEmployee) ? (int)e.Id : Convert.ToInt32(idEmployee);
                if (e.Id == id)
                {
                    if (e.ContractTypeName == "MonthlySalaryEmployee")
                    {
                        e.Salary = e.MonthlySalary * 12;
                    }
                    else
                    {
                        e.Salary = 120 * e.HourlySalary * 12;
                    }
                    ListFilter.Add(e);
                }   
            }            
            return ListFilter;
        }
    }
}