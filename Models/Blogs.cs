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
        [Display(Name = "Tin")]
        public string TITLE { get; set; }


        [Display(Name = "Mô tả ngắn")]
        public string DESCRIPTION_SHORT { get; set; }


        [Display(Name = "Chi tiết")]
        public string DETAIL { get; set; }


        [Display(Name = "Hình ảnh")]
        public string IMAGE { get; set; }


        [Display(Name = "Loại")]
        [Required(ErrorMessage = "Enter Your Title")]
        public int CATEGORY { get; set; }


        [Display(Name = "Vị trí")]
        [Required(ErrorMessage = "Enter Your Title")]
        public string LOCATIONS { get; set; }


        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Enter Your Title")]
        public int PUBLICS { get; set; }


        [Display(Name = "Ngày Public")]
        [Required(ErrorMessage = "Enter Your Title")]
        public DateTime DATE_PUBLIC { get; set; }


        public List<Blogs> ShowAllBlogs { get; set; }
    }
}