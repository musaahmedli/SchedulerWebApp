using AutoMapper;
using BusinessLogicLib.IServices;
using DataAccessLib.IRepositories;
using DataAccessLib.Repositories;
using DTO.MeetingWeek;
using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.Services
{
    public class MeetingWeekService : IMeetingWeekService
    {
        readonly IMeetingWeekRepo repo;
        readonly IMapper mapper;
        public MeetingWeekService(IMeetingWeekRepo repo, IMapper mapper)
        {
            this.repo = repo;

            this.mapper = mapper;

        }

        public async Task<bool> AnyIsActiveWeek()
        {
            return await repo.AnyIsActiveWeek();
        }

        public async Task Close()
        {
            await repo.Close();
        }

        public async Task<MeetingWeekToListDTO> GetActiveWeekDays()
        {
            MeetingWeekToListDTO meetingWeekToListDTO = mapper.Map<MeetingWeekToListDTO>(await repo.GetActiveWeekDays());

            return meetingWeekToListDTO;
        }

        public async Task Open(MeetingWeekToAddDTO meeting)
        {
            await repo.Open(mapper.Map<MeetingWeek>(meeting));
        }

        public async Task<List<MeetingWeekToListDTO>> SeeArchive()
        {
            List<MeetingWeekToListDTO> archiveWeeks = mapper.Map<List<MeetingWeekToListDTO>>(await repo.SeeArchive());
            return archiveWeeks;
        }
    }
}
