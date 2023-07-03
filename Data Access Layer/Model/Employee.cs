using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Model
{
    

    public class Employee
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z]{3,20})", ErrorMessage = "Name can only have alphabets and must be 10 digits.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([0-9]{6})", ErrorMessage = "Salary should be numbers only.")]
        public int Salary { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="Please enter a valid email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.DateTime, ErrorMessage ="Invalid Date. Please enter a valid date.")]
        public DateTime JoiningDate { get; set; }

        [Required]
        public bool Status { get; set; }


        [Required]
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        [NotMapped]
        public virtual Department Departments { get; set; }
    }
}
