using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{//chua xong
    //khai bao ten bang
    [Table("Suppliers")]
    public class Suppliers
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }
        [Required]// khong dc null
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? Order { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UrlSlide { get; set; }
        public string MetaKey { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        [Required]
        public DateTime CreateBy { get; set; }
        [Required]
        public int UpdateBy { get; set; }

        [Required]
        public DateTime UpdateByAt { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
