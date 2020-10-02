using Mvc;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class DriverController : Controller
    {
        // GET: Driver
        public ActionResult Index()
        {
            IEnumerable<mvcDriverModel> driverList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Driver").Result;
            driverList = response.Content.ReadAsAsync<IEnumerable<mvcDriverModel>>().Result;
            return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcDriverModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Driver/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcDriverModel>().Result);
            }


        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcDriverModel driver)
        {
            if (driver.Driver_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Driver", driver).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Driver/" + driver.Driver_id, driver).Result;
                TempData["SuccessMessage"] = "Updated ccessfully";
            }


            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Driver/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted ccessfully";
            return RedirectToAction("Index");
        }
    }
}