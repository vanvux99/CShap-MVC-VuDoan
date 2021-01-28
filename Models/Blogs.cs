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
        public int Id { get; set; }


        [Required(ErrorMessage = "Enter Your Title")]
        [Display(Name = "Tin")]
        public string Title { get; set; }


        [Display(Name = "Mô tả ngắn")]
        public string DescriptionShort { get; set; }


        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }


        [Display(Name = "Hình ảnh")]
        public string Image { get; set; }


        [Display(Name = "Loại")]
        [Required(ErrorMessage = "Enter Your Title")]
        public string Category { get; set; }


        [Display(Name = "Vị trí")]
        [Required(ErrorMessage = "Enter Your Title")]
        public string Locations { get; set; }


        [Display(Name = "Trạng thái")]
        [Required(ErrorMessage = "Enter Your Title")]
        public string Publics { get; set; }


        [Display(Name = "Ngày Public")]
        [Required(ErrorMessage = "Enter Your Title")]
        public DateTime DatePublic { get; set; }


        public List<Blogs> ShowAllBlogs { get; set; }

        public List<Blogs> ShowBlogSearch { get; set; }
    }
}