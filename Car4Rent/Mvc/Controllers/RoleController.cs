using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
       public ActionResult Index()
        {
            IEnumerable<mvcRoleModel> roleList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Role").Result;
            roleList = response.Content.ReadAsAsync<IEnumerable<mvcRoleModel>>().Result;
            return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcRoleModel());
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Role/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcRoleModel>().Result);
            }

            
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcRoleModel role)
        {
            if (role.Role_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Role", role).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Role/"+role.Role_id,role).Result;
                TempData["SuccessMessage"] = "Updated ccessfully";
            }
            

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Role/"+id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted ccessfully";
            return RedirectToAction("Index");
        }
    }
}