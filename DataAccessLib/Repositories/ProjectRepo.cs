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
    public class ProjectRepo : IProjectRepo
    {
        private readonly Context _context;
        public ProjectRepo(Context context)
        {
            _context = context;
        }
        public async Task Add(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int projectId)
        {
            Project project = _context.Projects.Find(projectId);
            project.IsDeleted = true;
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> Get()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetById(int projectId)
        {
            return await _context.Projects.FindAsync(projectId);
        }

        public async Task<List<Project>> GetDeleteds()
        {
            return await _context.Projects.IgnoreQueryFilters().Where(m => m.IsDeleted).ToListAsync();
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }
    }
}
