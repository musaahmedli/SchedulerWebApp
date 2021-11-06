using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IOrganizationRepo
    {
        Task Add(Organization organization);
        Task<List<Organization>> Get();
        Task<Organization> GetById(int organizationId);
        Task Delete(int organizationId);
        void Update(Organization organization);
    }
}
