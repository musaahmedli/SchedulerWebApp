using DTO.MeetingDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IMeetingService
    {
        Task Add(MeetingToAddDTO meeting);
        Task Delete(int meetingId);
        Task<List<MeetingToListDTO>> Get(int meetingDaysId);
        Task<List<MeetingToListDTO>> GetMeetingOfEmployee(int employeeId, int meetingDaysId);
        Task<MeetingToListDTO> GetById(int meetingId);
        void Update(MeetingToUpdateDTO meeting);
    }
}
