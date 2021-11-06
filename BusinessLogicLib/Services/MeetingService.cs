using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.MeetingDTOs;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class MeetingService : IMeetingService
    {
        readonly IMeetingRepo _repo;
        readonly IMapper _mapper;
        public MeetingService(IMeetingRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task Add(MeetingToAddDTO meetingToAddDTO)
        {
            await _repo.Add(_mapper.Map<Meeting>(meetingToAddDTO));
        }

        public async Task Delete(int meetingId)
        {
            await _repo.Delete(meetingId);
        }

        public async Task<List<MeetingToListDTO>> Get(int meetingDaysId)
        {
            return _mapper.Map<List<MeetingToListDTO>>(await _repo.Get(meetingDaysId));
        }

        public async Task<MeetingToListDTO> GetById(int meetingId)
        {
            return _mapper.Map<MeetingToListDTO>(await _repo.GetById(meetingId));
        }

        public async Task<List<MeetingToListDTO>> GetMeetingOfEmployee(int employeeId,int meetingDaysId)
        {
            return _mapper.Map<List<MeetingToListDTO>>(await _repo.GetMeetingOfEmployee(employeeId,meetingDaysId));
        }

        public void Update(MeetingToUpdateDTO meeting)
        {
            _repo.Update(_mapper.Map<Meeting>(meeting));
        }
    }
}
