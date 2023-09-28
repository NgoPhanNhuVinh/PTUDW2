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
    [Table("Orders")]
    public class Orders
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }
        [Required]// khong dc null
        public int UserID { get; set; }
        [Required]
        public string ReceiverAddress { get; set; }
        public string Note { get; set; }

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
