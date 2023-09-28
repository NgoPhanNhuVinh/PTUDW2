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
    [Table("Menus")]
    public class Menus
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }
        [Required]// khong dc null
        public string Name { get; set; }

        public int? TableId { get; set; }

        public string TypeMenu { get; set; }

        public string Position { get; set; }

        public string Link { get; set; }

        public int? Parentid { get; set; }

        public int? Order { get; set; }
        [Required]
        public int CreateBy { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }

        [Required]
        public int UpdateBy { get; set; }
        [Required]
        public DateTime UpdateAt { get; set; }

        [Required]
        public int Status { get; set; }
    }
}
