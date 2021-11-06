using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IEmployeeRepo
    {
        Task Add(Employee employee);
        Task<List<Employee>> Get();
        Task<Employee> GetById(int employeeId);
        Task Delete(int employeeId);
        void Update(Employee employee);
        Task<Employee> Login(Employee employee);
        Task<List<Employee>> GetEmployeesOfMeeting(int meetingId);
    }
}
