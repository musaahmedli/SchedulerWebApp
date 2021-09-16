using DTO.OrganizationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IOrganizationService
    {
        Task Add(OrganizationToAddDTO organizationToAddDTO);
        Task<List<OrganizationToListDTO>> Get();
        Task<OrganizationToListDTO> GetById(int organizationId);
        Task Delete(int organizationId);
        void Update(OrganizationToUpdateDTO organizationToUpdateDTO);
        Task<List<OrganizationToListDTO>> ShowDeletedOrganizations();
    }
}
