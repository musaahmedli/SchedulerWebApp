
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IDepartmentRepo
    {
        Task Add(Department department);
        Task<List<Department>> Get();
        Task<Department> GetById(int departmentId);
        Task Delete(int departmentId);
        void Update(Department department);
        Task<List<Department>> GetDeleteds();
    }
}
