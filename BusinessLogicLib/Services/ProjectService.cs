using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.ProjectDTOs;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _repo;
        private readonly IMapper _mapper;
        public ProjectService(IProjectRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Add(ProjectToAddDTO project)
        {
            await _repo.Add(_mapper.Map<Project>(project));
        }

        public async Task Delete(int projectId)
        {
            await _repo.Delete(projectId);
        }

        public async Task<List<ProjectToListDTO>> Get()
        {
            return _mapper.Map<List<ProjectToListDTO>>(await _repo.Get());
        }

        public async Task<ProjectToListDTO> GetById(int projectId)
        {
            return _mapper.Map<ProjectToListDTO>(await _repo.GetById(projectId));
        }

        public void Update(ProjectToUpdateDTO project)
        {
            _repo.Update(_mapper.Map<Project>(project));
        }
    }
}
