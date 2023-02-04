using EmployeeRep.Models;
using EmployeeRep.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRep.Controllers
{
    public class employeeController : Controller
    {
        IEmployeeRepo employeeRepo; //= new EmployeeRepo();
        public employeeController(IEmployeeRepo _employeeRepo)
        {
                
            employeeRepo = _employeeRepo;
        }
        public IActionResult Index()
        {
           List<Employee> employees=  employeeRepo.getall();

            return View(employees);
        }
        [Authorize]
        public IActionResult GetByid(int id)
        {
            Employee employee = employeeRepo.getbyId(id);
            return View(employee);
        }
        public IActionResult Add()
        {
            List<Employee> employees = employeeRepo.getall();
            return View(employees);
        }

        public IActionResult AddEmployeeDb(Employee employee)
        {
            //DB.Employees.Add(employee);
            //DB.SaveChanges();
            employeeRepo.create(employee);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            List<Employee> employees = employeeRepo.getall();
            Employee? employee = employeeRepo.getbyId(id);
            ViewBag.emp = employees;
            if (employee == null)
                return View("Error");
            else
                return View(employee);
        }
        public IActionResult UpdateDB(Employee employee , int id )
        {
           employeeRepo.update(id, employee);

            return RedirectToAction(nameof(Index));
        }
         
        public IActionResult Delete(int id)
        {
           employeeRepo.delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
