using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Model
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
