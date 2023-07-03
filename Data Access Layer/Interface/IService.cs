using Data_Access_Layer.Model;

namespace Data_Access_Layer.Interface
{
    public interface IService
    {
        Employee GetEmployee(int id);
        void Create(Employee employee);
        List<Employee> Read();
        void Update(Employee employee);
        void Delete(int id);
        Department GetDepartment(int id);
    }
}
