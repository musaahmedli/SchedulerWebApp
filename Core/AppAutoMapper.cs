using AutoMapper;
using DTO.DaysOfWeekDTOs;
using DTO.EmployeeDTOs;
using DTO.EmployeeMeetingDTOs;
using DTO.MeetingDays;
using DTO.MeetingDTOs;
using DTO.MeetingWeek;
using DTO.OrganizationDTOs;
using DTO.PositionDTOs;
using DTO.ProjectDTOs;
using DTO.SectorDTOs;
using EntityLib;
using System;
using System.Linq.Expressions;

namespace Core
{
    public class AppAutoMapper :Profile
    {
        public AppAutoMapper()
        {

            //organization Mapping
            CreateMap<Organization, OrganizationToListDTO>().ReverseMap();
            CreateMap<Organization, OrganizationToAddDTO>().ReverseMap();
            CreateMap<Organization, OrganizationToUpdateDTO>().ReverseMap();
            CreateMap<OrganizationToListDTO, OrganizationToUpdateDTO>().ReverseMap();

            //Department Mapping
            CreateMap<DepartmentToAddDTO, Department>().ReverseMap();
            CreateMap<DepartmentToListDTO, Department>().ReverseMap();
            CreateMap<DepartmentToUpdateDTO, Department>().ReverseMap();
            CreateMap<DepartmentToUpdateDTO, DepartmentToListDTO>().ReverseMap();

            //Sector Mapping
            CreateMap<Sector, SectorToListDTO>().ReverseMap();
            CreateMap<Sector, SectorToUpdateDTO>().ReverseMap();
            CreateMap<Sector, SectorToAddDTO>().ReverseMap();
            CreateMap<SectorToListDTO, SectorToUpdateDTO>().ReverseMap();

            //Position Mapping
            CreateMap<Position, PositionToListDTO>().ReverseMap();
            CreateMap<Position, PositionToAddDTO>().ReverseMap();
            CreateMap<Position, PositionToUpdateDTO>().ReverseMap();
            CreateMap<PositionToUpdateDTO, PositionToListDTO>().ReverseMap();

            //EmployeeMapping
            CreateMap<Employee, EmployeeToListDTO>().ReverseMap();
            CreateMap<Employee, EmployeeToUpdateDTO>().ReverseMap();
            CreateMap<Employee, EmployeeToAddDTO>().ReverseMap();
            CreateMap<EmployeeToUpdateDTO, EmployeeToListDTO>().ReverseMap();

            //Project Mapping
            CreateMap<Project, ProjectToListDTO>().ReverseMap();
            CreateMap<Project, ProjectToUpdateDTO>().ReverseMap();
            CreateMap<Project, ProjectToAddDTO>().ReverseMap();
            CreateMap<ProjectToUpdateDTO, ProjectToListDTO>().ReverseMap();

            //EmployeeMeeting Mapping
            CreateMap<EmployeeMeeting, EmployeeMeetingToListDTO>().ReverseMap();

            //Meeting Mapping
            CreateMap<Meeting, MeetingToListDTO>().ReverseMap();
            CreateMap<Meeting, MeetingToAddDTO>().ReverseMap();
            CreateMap<Meeting, MeetingToUpdateDTO>().ReverseMap();
            CreateMap<MeetingToListDTO, MeetingToUpdateDTO>().ReverseMap();
            
            //MeetingWeek Mapping
            CreateMap<MeetingWeek, MeetingWeekToAddDTO>().ReverseMap();
            CreateMap<MeetingWeek, MeetingWeekToListDTO>().ReverseMap();
            
            //MeetingDays Mapping
            CreateMap<MeetingDays, MeetingDaysToListDTO>().ReverseMap();
            
            //DaysOfWeek Mapping
            CreateMap<DaysOfWeek, DaysOfWeekToListDTO>().ReverseMap();

            //Expression Mapping
            //CreateMap<Expression<Func<MeetingToListDTO, bool>>, Expression<Func<Meeting, bool>>>().ReverseMap();
        }
    }
}
