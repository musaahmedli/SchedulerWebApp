using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IProjectRepo
    {
        Task Add(Project project);
        Task<List<Project>> Get();
        Task<Project> GetById(int projectId);
        Task Delete(int projectId);
        void Update(Project project);
    }
}
