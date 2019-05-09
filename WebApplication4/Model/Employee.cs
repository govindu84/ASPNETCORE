using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore.Model
{
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Full Name")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(10)")]
        [DisplayName("Emp. Code")]
        public string EmpCode { get; set; }
        [EmailAddress]
        [Required]
        [Display(Name = "Personal Email")]
        [Column(TypeName = "varchar(1000)")]
        public string Email { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Position { get; set; }
       
       
    }

}

