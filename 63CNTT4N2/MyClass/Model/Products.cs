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
    [Table("Products")]
    public class Products
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }
        [Required]// khong dc null
        public int CatID { get; set; }
        [Required]
        public string Name { get; set; }
        public string SupplierID { get; set; }

        public string Slug { get; set; }
        [Required]
        public string Detail { get; set; }
       
        public string Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal SalePrice { get; set; }
        [Required]
        public int Amout { get; set; }

        [Required]
        public string MetaDesc { get; set; }
        [Required]
        
      
    }
}
