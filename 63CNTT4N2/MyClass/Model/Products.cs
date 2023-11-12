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
    [Table("Products")]
    public class Products
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }

        [Display(Name = "Loai san pham")]
        [Required(ErrorMessage = "loai sản phẩm không được để trống")]
        public int CatID { get; set; }
        [Display(Name = "Tên SAN PHAM")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; }

        [Display(Name = "Ma nha cung cap")]
        [Required(ErrorMessage = "nha cung cap không được để trống")]
        public int SupplierID { get; set; }

        [Display (Name="Ten rut gon")]
        public string Slug { get; set; }

        [Display(Name = "Hinh anh")]
        public string Image { get; set; }

        [Display(Name = "gia san pham")]
        [Required(ErrorMessage = "gia san pham không được để trống")]
        public decimal Price { get; set; }

        [Display(Name = "gia ban")]
        [Required(ErrorMessage = "gia ban không được để trống")]

        public decimal SalePrice { get; set; }

        [Display(Name = "So luong")]
        [Required(ErrorMessage = "so luong không được để trống")]
        public int Amout { get; set; }

        [Display(Name = "Mo ta")]
        [Required(ErrorMessage = "mo ta không được để trống")]
        public string MetaDesc { get; set; }

        [Display(Name = "Tu khoa")]
        [Required(ErrorMessage = "tu khoa không được để trống")]
        public string MetaKey { get; set; }

        [Display(Name = "Nguoi tao")]
        [Required(ErrorMessage = "nguoi tao không được để trống")]
        public int CreateBy { get; set; }

        [Display(Name = "Ngay tao")]
        [Required(ErrorMessage = "ngay taokhông được để trống")]
        public DateTime CreateAt { get; set; }

        [Display(Name = "Nguoi cap nhap")]
        [Required(ErrorMessage = "Nguoi cap nhap không được để trống")]
        public int UpdateBy { get; set; }

        [Display(Name = "Ngay cap nhap")]
        [Required(ErrorMessage = "ngay cap nhap không được để trống")]
        public DateTime UpdateAt { get; set; }

        [Display(Name="Trang thai")]
        public int? Status { get; set; }

    }
}
