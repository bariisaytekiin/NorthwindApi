using NorthwindApi.DTO;
using NorthwindApi.Models.Context;

namespace NorthwindApi.Repository
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> GetEmployees();

        string CreateEmployee(EmployeeDTO employeeDTO);

        List<EmployeeDTO> GetEmployeesOrderBy();//A-z sıralma

        List<EmployeeDTO> GetEmployeesOrderByDesc();//Z-A sıralma

        List<Order> GetEmployeesSales();//Çalışanların yaptığı satış

        List<EmployeeDTO> GetRandomEmployee();//Random Çalışan atama
    }
}
