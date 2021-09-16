using DataAccessLib.IRepositories;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly Context _context;
        public EmployeeRepo(Context context)
        {
            _context = context;
        }
        public async Task Add(Employee employee)
        {
            employee.Password = Hasher.HashPassword(employee.Password);
            if (employee.Image != null)
            {
                _context.Employees.Add(employee);
                _context.Entry(employee).Property("ImagePath").IsModified = false;
            }
            else
            {
                await _context.Employees.AddAsync(employee);
            }
            _context.SaveChanges();
        }

        public async Task Delete(int employeeId)
        {
            Employee employee = await _context.Employees.FindAsync();
            employee.IsDeleted = true;
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public async Task<List<Employee>> Get()
        {
            return await _context.Employees.Include(m => m.Position).Include(m => m.Sector).ThenInclude(m=>m.Department).ThenInclude(m=>m.Organization).ToListAsync();
        }

        public async Task<Employee> GetById(int employeeId)
        {
            return await _context.Employees.Include(m => m.Position).Include(m => m.Sector).ThenInclude(m => m.Department).ThenInclude(m => m.Organization).FirstOrDefaultAsync(m=>m.EmployeeId==employeeId);
        }

        public async Task<List<Employee>> GetDeleteds()
        {
            return await _context.Employees.IgnoreQueryFilters().Where(m=>m.IsDeleted).Include(m => m.Position).Include(m => m.Sector).ToListAsync();
        }

        public async Task<bool> Login(Employee employee)
        {
            employee.Password = Hasher.HashPassword(employee.Password);
            if(await _context.Employees.FirstOrDefaultAsync(m=>m.Username==employee.Username && m.Password == employee.Password) ==null)
            {
                return false;
            }
            return true;
            
        }

        public void Update(Employee employee)
        {
            if (employee.Password != null && employee.ImagePath!=null)
            {
                employee.Password = Hasher.HashPassword(employee.Password);
                _context.Employees.Update(employee);
            }
            else if (employee.Password!=null && employee.ImagePath==null)
            {
                employee.Password = Hasher.HashPassword(employee.Password);
                _context.Employees.Update(employee);
                _context.Entry(employee).Property("ImagePath").IsModified = false;
            }
            else if (employee.Password==null &&employee.ImagePath!=null)
            {
                _context.Employees.Update(employee);
                _context.Entry(employee).Property("Password").IsModified = false;
            }
            else
            {
                _context.Employees.Update(employee);
                _context.Entry(employee).Property("Password").IsModified = false;
                _context.Entry(employee).Property("ImagePath").IsModified = false;
            }
            _context.SaveChanges();
        }
    }
}
