using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    //khai bao ten bang
    [Table("Suppliers")]
    public class Suppliers
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ten khong duoc de trong")]// khong dc null
        [Display(Name = "Tên nha cung cap ")]
        public string Name { get; set; }

        [Display(Name = "Hinh anh ")]
        public string Image { get; set; }

        [Display(Name = "Link rut gon")]
        public string Slug { get; set; }

        [Display(Name = "Sap xep ")]
        public int? Order { get; set; }

        [Display(Name = "Ten day du")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "So dien thoai")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ten khong duoc de trong")]
        [Display(Name = "Lien ket")]
        public string UrlSite { get; set; }

        [Required(ErrorMessage = "Mo ta khong duoc de trong")]
        [Display(Name = "Mo ta")]
        public string MetaDesc { get; set; }

        [Required(ErrorMessage = "Tu khoa khong duoc de trong")]
        [Display(Name = "Tu khoa")]
        public string MetaKey { get; set; }

        [Required(ErrorMessage = "Nguoi tao khong duoc de trong")]
        [Display(Name = "Ngay tao")]
        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "Ten khong duoc de trong")]
        [Display(Name = "Nguoi tao")]
        public int CreateBy { get; set; }


        [Required(ErrorMessage = "Nguoi cap nhap khong duoc de trong")]
        [Display(Name = "Nguoi Cap nhap")]
        public int UpdateBy { get; set; }


        [Required(ErrorMessage = "Ngay cap nhap khong duoc de trong")]
        [Display(Name = "Ngay Cap nhap ")]
        public DateTime UpdateAt { get; set; }
      
        [Display(Name = "Trang thai")]
        public int? Status { get; set; }// cho phep null
    }
}
