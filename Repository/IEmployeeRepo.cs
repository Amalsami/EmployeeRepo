using EmployeeRep.Models;

namespace EmployeeRep.Repository
{
    public interface IEmployeeRepo
    {
        int create(Employee employee);
        int delete(int id);
        List<Employee> getall();
        Employee getbyId(int id);
        int update(int id, Employee employee);
    }
}