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
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            IEnumerable<mvcImageModel> imgList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Image").Result;
            imgList = response.Content.ReadAsAsync<IEnumerable<mvcImageModel>>().Result;
            return View();
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new mvcImageModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Image/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcImageModel>().Result);
            }


        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcImageModel img)
        {
            if (img.Image_id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Image", img).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Image/" + img.Image_id, img).Result;
                TempData["SuccessMessage"] = "Updated ccessfully";
            }


            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Image/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted ccessfully";
            return RedirectToAction("Index");
        }
    }
}