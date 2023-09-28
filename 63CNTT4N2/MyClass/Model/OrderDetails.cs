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
    [Table("OrderDetails")]
    public class OrderDetails
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Amaout{ get; set; }

        
    }
}
