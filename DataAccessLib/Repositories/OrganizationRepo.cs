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
    public class OrganizationRepo : IOrganizationRepo
    {
        private readonly Context _context;
        public OrganizationRepo(Context context)
        {
            _context = context;
        }
        public async Task Add(Organization organization)
        {
            await _context.Organizations.AddAsync(organization);
            _context.SaveChanges();
        }

        public async Task Delete(int organizationId)
        {
            Organization organization = await _context.Organizations.FindAsync(organizationId);
            organization.IsDeleted = true;
            _context.Organizations.Update(organization);
            _context.SaveChanges();
        }

        public async Task<List<Organization>> Get()
        {
            return await _context.Organizations.Include(m=>m.ParentOrganization).ToListAsync();
        }

        public async Task<Organization> GetById(int organizationId)
        {
            return await _context.Organizations.FindAsync(organizationId);
        }

        public void Update(Organization organization)
        {
            _context.Organizations.Update(organization);
            _context.SaveChanges();
        }
        public async Task<List<Organization>> ShowDeletedOrganizations()
        {
            return await _context.Organizations.IgnoreQueryFilters().Where(m=>m.IsDeleted).ToListAsync();
        } 
    }
}
