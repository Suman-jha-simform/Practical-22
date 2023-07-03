using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Practical_22___API.Dtos
{
    public class EmployeeDto
    {
        public string Name { get; set; }

        public int Salary { get; set; }

        public int DepartmentId { get; set; }

        public string Email { get; set; }   
    }
}
