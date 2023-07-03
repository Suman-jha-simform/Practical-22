namespace Practical_22___API.Dtos
{
    public class UpdateEmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Salary { get; set; }

        public int DepartmentId { get; set; }

        public string Email { get; set; }
    }
}
