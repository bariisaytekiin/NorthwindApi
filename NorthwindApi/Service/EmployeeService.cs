using NorthwindApi.DTO;
using NorthwindApi.Models.Context;
using NorthwindApi.Repository;

namespace NorthwindApi.Service
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly northwndContext _context;

        public EmployeeService(northwndContext context)
        {
            _context = context;
        }

        public string CreateEmployee(EmployeeDTO employeeDTO)//Çalışan Oluşturma
        {
            Employee employee = new Employee();

            employee.FirstName = employeeDTO.FirstName;
            employee.LastName = employeeDTO.LastName;
            employee.Title = employeeDTO.Title;
            employee.TitleOfCourtesy = employeeDTO.TitleOfCourtesy;
            

            _context.Employees.Add(employee);

            if (_context.SaveChanges() > 0)
            {
                return "Kayıt Başarılı";
            }
            else
            {
                return "Bir hata oluştu";
            }
        }

   

        public List<EmployeeDTO> GetEmployees()//Çalışan Listeleme
        {
            #region Uzun yol
            //var employees = _context.Employees.ToList();

            //List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();

            //foreach (var employee in employees)
            //{
            //    EmployeeDTO employeeDTO = new EmployeeDTO()
            //    {
            //        FirstName = employee.FirstName,
            //        LastName = employee.LastName,
            //        Title = employee.Title,
            //        TitleOfCourtesy = employee.TitleOfCourtesy
            //    };
            //    employeeDTOs.Add(employeeDTO);
            //} 

            #endregion

            var employeeDTOs = _context.Employees.Select(x => new EmployeeDTO
            {
                Id=x.EmployeeId,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Title=x.Title,
                TitleOfCourtesy=x.TitleOfCourtesy
            }).ToList();

            
            return employeeDTOs;
        }

        public List<EmployeeDTO> GetEmployeesOrderBy()//A-Z çalışan listeleme
        {
            var employeeDTOs = _context.Employees.Select(x => new EmployeeDTO
            {
                Id = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy
            }).OrderBy(x => x.FirstName).ToList();


            return employeeDTOs;
        }

        public List<EmployeeDTO> GetEmployeesOrderByDesc()//Z-A çalışan listeleme
        {
            var employeeDTOs = _context.Employees.Select(x => new EmployeeDTO
            {
                Id = x.EmployeeId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Title = x.Title,
                TitleOfCourtesy = x.TitleOfCourtesy
            }).OrderByDescending(x => x.FirstName).ToList();


            return employeeDTOs;
        }

        public List<Order> GetEmployeesSales()//Çalışanların satışları id göre sıralama
        {
            var orders = _context.Orders.OrderBy(x=>x.EmployeeId).ToList();

            return orders;
            
        }

        public List<EmployeeDTO> GetRandomEmployee()//Random çalışan verme
        {
            Random random = new Random();

            var rnd= random.Next(1,_context.Employees.Count()-1);
            var employe = _context.Employees.Find(rnd);

            EmployeeDTO employeeDTO = new EmployeeDTO()
            {
                Id = employe.EmployeeId,
                FirstName = employe.FirstName,
                LastName = employe.LastName,
                Title=employe.Title,
                TitleOfCourtesy=employe.TitleOfCourtesy
            };

            List<EmployeeDTO> emp= new List<EmployeeDTO>();
            emp.Add(employeeDTO);
            return emp;
        }
    }
}
