using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindApi.DTO;
using NorthwindApi.Models.Context;
using NorthwindApi.Repository;

namespace NorthwindApi.Controllers
{
    //[Route("api/[controller]")]//enson burası dahil edildiği için program.cs endpoint ezilir.
    //[ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult GetEmployees()
        {
            #region Bu kod yapısını service dahil ediyoruz
            //var employees = _context.Employees.ToList();

            //List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();

            //foreach (var employee in employees)
            //{
            //    EmployeeDTO employeeDTO = new EmployeeDTO()
            //    {
            //        FirstName= employee.FirstName,
            //        LastName= employee.LastName,
            //        Title=employee.Title,
            //        TitleOfCourtesy=employee.TitleOfCourtesy
            //    };
            //    employeeDTOs.Add(employeeDTO);
            //} 
            #endregion


            return Ok(_employeeRepository.GetEmployees());
        }

        public IActionResult GetEmployeesOrderBy()
        {
            return Ok(_employeeRepository.GetEmployeesOrderBy());
        }
        public IActionResult GetEmployeesOrderByDesc()
        {
            return Ok(_employeeRepository.GetEmployeesOrderByDesc());
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDTO employeeDTO)
        {
            var result = _employeeRepository.CreateEmployee(employeeDTO);
            return Ok(result);
        }

        public IActionResult GetEmployeesSales()
        {
          return Ok(  _employeeRepository.GetEmployeesSales());
        }

        public IActionResult GetRandomEmployee()
        {
            return Ok(_employeeRepository.GetRandomEmployee());
        }
    }
}
