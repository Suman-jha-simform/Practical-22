using Data_Access_Layer.Interface;
using Data_Access_Layer.Model;
using Data_Access_Layer.Singleton;


namespace Data_Access_Layer.Services
{
    public class Service : IService
    {
        private  ApplicationContext _context = SingletonClass.GetInstance();
        private  Logger _logger = SingletonClass.GetLoggerInstance();

        
        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            _logger.Log("Employee Added Successfully");
        }

        public List<Employee> Read()
        {
            var employees =  _context.Employees.Where(x => x.Status == true).ToList();
            _logger.Log("Employee list fetched");
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var empolyee = _context.Employees.Where(x => x.Id == id && x.Status == true).SingleOrDefault();
            _logger.Log("Single employee details returned");
            return empolyee;
        }

        public void Update(Employee employee)
        {
            var emp = _context.Employees.SingleOrDefault(x => x.Id == employee.Id);
            emp.Id=employee.Id;
            emp.Name=employee.Name;
            emp.Salary=employee.Salary;
            emp.DepartmentId=employee.DepartmentId;
            emp.Status=employee.Status;
            emp.Email=employee.Email;
            _context.SaveChanges();
            _logger.Log("Employee details updated successfully.");
        }

        public void Delete(int id)
        {
            var emp = _context.Employees.SingleOrDefault(x => x.Id == id);
            emp.Status = false;
            _context.SaveChanges();
            _logger.Log("Employee deletion successfull");
        }

        public Department GetDepartment(int id)
        {
            var department = _context.Departments.Where(x => x.DeptId == id).SingleOrDefault();
            if(department == null)
            {
                return null;
            }
            else
            {
                return department;
            }
        }
    }
}
