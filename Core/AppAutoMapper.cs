using AutoMapper;
using DTO.EmployeeDTOs;
using DTO.OrganizationDTOs;
using DTO.PositionDTOs;
using DTO.ProjectDTOs;
using DTO.SectorDTOs;
using EntityLib;
using System;

namespace Core
{
    public class AppAutoMapper :Profile
    {
        public AppAutoMapper()
        {
            CreateMap<Organization, OrganizationToListDTO>().ReverseMap();
            CreateMap<Organization, OrganizationToAddDTO>().ReverseMap();
            CreateMap<Organization, OrganizationToUpdateDTO>().ReverseMap();
            CreateMap<OrganizationToListDTO, OrganizationToUpdateDTO>().ReverseMap();

            CreateMap<DepartmentToAddDTO, Department>().ReverseMap();
            CreateMap<DepartmentToListDTO, Department>().ReverseMap();
            CreateMap<DepartmentToUpdateDTO, Department>().ReverseMap();
            CreateMap<DepartmentToUpdateDTO, DepartmentToListDTO>().ReverseMap();

            CreateMap<Sector, SectorToListDTO>().ReverseMap();
            CreateMap<Sector, SectorToUpdateDTO>().ReverseMap();
            CreateMap<Sector, SectorToAddDTO>().ReverseMap();
            CreateMap<SectorToListDTO, SectorToUpdateDTO>().ReverseMap();

            CreateMap<Position, PositionToListDTO>().ReverseMap();
            CreateMap<Position, PositionToAddDTO>().ReverseMap();
            CreateMap<Position, PositionToUpdateDTO>().ReverseMap();
            CreateMap<PositionToUpdateDTO, PositionToListDTO>().ReverseMap();

            CreateMap<Employee, EmployeeToListDTO>().ReverseMap();
            CreateMap<Employee, EmployeeToUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeToAddDTO>().ReverseMap();
            CreateMap<EmployeeToUpdateDTO, EmployeeToListDTO>().ReverseMap();

            CreateMap<Project, ProjectToListDTO>().ReverseMap();
            CreateMap<Project, ProjectToUpdateDTO>().ReverseMap();
            CreateMap<Project, ProjectToAddDTO>().ReverseMap();
            CreateMap<ProjectToUpdateDTO, ProjectToListDTO>().ReverseMap();
        }
    }
}
