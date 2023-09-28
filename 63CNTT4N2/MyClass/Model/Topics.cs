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
    [Table("Topics")]
    public class Topics
    {
        // khai bao truong, khoa chinh
        [Key]
        public int Id { get; set; }
        [Required]// khong dc null
        public string Name { get; set; }
        public string Slug { get; set; }
        public int? ParentId { get; set; }

        public int? Order { get; set; }
        [Required]
        public string MetaDesc { get; set; }
        [Required]
        public string MetaKey { get; set; }
        [Required]
        public int CreateBy { get; set; }
        [Required]
        public DateTime CreateAt { get; set; }
        [Required]
        public int UpdateBy { get; set; }

        [Required]
        public DateTime UpdatAt { get; set; }
        [Required]
        public int Status { get; set; }
    }
}
