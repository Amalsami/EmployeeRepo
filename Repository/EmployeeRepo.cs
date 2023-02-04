using EmployeeRep.Models;

namespace EmployeeRep.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        CompanyDBContext dBContext;
        public EmployeeRepo(CompanyDBContext _dBContext)
        {
            dBContext = _dBContext;
                
        }

        //get all 
        public List<Employee> getall()
        {

            return dBContext.Employees.ToList();
        }

        // getbyID
        public Employee getbyId(int id)
        {
            return dBContext.Employees.FirstOrDefault(s => s.SSN == id);
        }
        //create
        public int create(Employee employee)
        {
            dBContext.Employees.Add(employee);
            int row = dBContext.SaveChanges();

            return row;

        }
        //update
        public int update(int id, Employee employee)
        {
            Employee oldemployee = dBContext.Employees.FirstOrDefault(s => s.SSN == id);

            oldemployee.Fname = employee.Fname;
            oldemployee.Lname = employee.Lname;
            oldemployee.Salary = employee.Salary;
            oldemployee.Sex = employee.Sex;
            oldemployee.Minit = employee.Minit;
            oldemployee.Address = employee.Address;
            oldemployee.BirthDate = employee.BirthDate;
            oldemployee.deptId = employee.deptId;
            int row = dBContext.SaveChanges();
            return row;
        }

        // delete
        public int delete(int id)
        {
            Employee employee = dBContext.Employees.FirstOrDefault(s => s.SSN == id);
            dBContext.Employees.Remove(employee);
            int row = dBContext.SaveChanges();
            return row;
        }
    }
}
