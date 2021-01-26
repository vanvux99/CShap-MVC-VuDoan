using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CShap_MVC_VuDoan.Models
{
    public class Blogs
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Enter Your Title")]
        public string TITLE { get; set; }


        public string DESCRIPTION_SHORT { get; set; }


        public string DETAIL { get; set; }


        public string IMAGE { get; set; }


        [Required(ErrorMessage = "Enter Your Title")]
        public int CATEGORY { get; set; }


        [Required(ErrorMessage = "Enter Your Title")]
        public string LOCATIONS { get; set; }


        [Required(ErrorMessage = "Enter Your Title")]
        public int PUBLICS { get; set; }


        [Required(ErrorMessage = "Enter Your Title")]
        public DateTime DATE_PUBLIC { get; set; }


    }
}