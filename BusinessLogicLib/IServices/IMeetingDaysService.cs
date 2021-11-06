using DTO.MeetingDays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLib.IServices
{
    public interface IMeetingDaysService
    {
        Task<List<MeetingDaysToListDTO>> GetActiveWeekDays();
    }
}
