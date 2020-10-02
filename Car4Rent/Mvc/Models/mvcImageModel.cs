using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class mvcImageModel
    {
        [Required(ErrorMessage = "this field is required")]
        public int Image_id { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public string Image_link { get; set; }
        [Required(ErrorMessage = "this field is required")]
        public int Car_id { get; set; }

    }
}