using DTO.MeetingWeek;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IMeetingWeekService
    {
        Task Open(MeetingWeekToAddDTO meeting);
        Task Close();
        Task<MeetingWeekToListDTO> GetActiveWeekDays();
        Task<List<MeetingWeekToListDTO>> SeeArchive();
        Task<bool> AnyIsActiveWeek();
    }
}
