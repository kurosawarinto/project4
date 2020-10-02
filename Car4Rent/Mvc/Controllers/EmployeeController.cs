using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcEmployeeModel> emplList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
            emplList = response.Content.ReadAsAsync<IEnumerable<mvcEmployeeModel>>().Result;
            return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcEmployeeModel());
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcEmployeeModel>().Result);
            }

            
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcEmployeeModel emp)
        {
            if (emp.Employee_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee/"+emp.Employee_id,emp).Result;
                TempData["SuccessMessage"] = "Updated ccessfully";
            }
            

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted ccessfully";
            return RedirectToAction("Index");
        }
    }
}