using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcDriverModel
    {
        [Required(ErrorMessage = "this field is required")]
        public int Driver_id { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Driver_name { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public System.DateTime DOB { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string IDCard { get; set; }
    }
}