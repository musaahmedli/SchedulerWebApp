using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DTO.MeetingDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class MeetingDaysService : IMeetingDaysService
    {
        readonly IMeetingDaysRepo repo;
        readonly IMapper mapper;
        public MeetingDaysService(IMeetingDaysRepo repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<List<MeetingDaysToListDTO>> GetActiveWeekDays()
        {
            return mapper.Map<List<MeetingDaysToListDTO>>(await repo.GetActiveWeekDays());
        }
    }
}
