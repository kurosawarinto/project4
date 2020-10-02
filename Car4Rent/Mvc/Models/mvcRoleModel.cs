using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcRoleModel
    {
        [Required(ErrorMessage = "this field is required")]
        public int Role_id { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Role_name { get; set; }
    }
}