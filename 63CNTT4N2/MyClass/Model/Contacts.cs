using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


 

namespace MyClass.Model
{
        //khai bao ten bang
        [Table("Contacts")]
        public class Contacts
        {
            // khai bao truong, khoa chinh
            [Key]
            public int Id { get; set; }

            [Required]// khong dc null
            public int UserID { get; set; }
            
            public string FullName { get; set; }
             
            public string Phone { get; set; }

            public string Email { get; set; }
            [Required]
            public string Title { get; set; }
            [Required]
            public string Detail { get; set; }
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



