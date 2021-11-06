using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IMeetingDaysRepo
    {
        Task<List<MeetingDays>> GetActiveWeekDays();
    }
}
