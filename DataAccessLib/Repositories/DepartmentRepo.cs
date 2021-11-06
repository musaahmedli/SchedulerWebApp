using DataAccessLib.IRepositories;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLib.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly Context _context;
        public DepartmentRepo(Context context)
        {
            _context = context;
        }
        public async Task Add(Department department)
        {
            await _context.Departments.AddAsync(department);
            _context.SaveChanges();
        }


        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public async Task<List<Department>> Get()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int departmentId)
        {
            return await _context.Departments.FindAsync(departmentId);
        }

        public async Task Delete(int departmentId)
        {
            Department department = await _context.Departments.FindAsync(departmentId);
            department.IsDeleted = true;
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public async Task<List<Department>> GetDepartmentsByOrganizationId(int organizationId)
        {
            List<Department> departments =  await _context.Departments.Where(dep => dep.OrganizationId == organizationId).ToListAsync();
            return departments;
        }
    }
}
