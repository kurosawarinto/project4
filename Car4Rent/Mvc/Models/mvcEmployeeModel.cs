using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcEmployeeModel
    {
        
        [Required(ErrorMessage ="this field is required")]
        public int Employee_id { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Employee_name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public System.DateTime DOB { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string IDCard { get; set; }

    }
}