using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IMeetingWeekRepo
    {
        Task Open(MeetingWeek week);
        Task Close();
        Task<MeetingWeek> GetActiveWeekDays();
        Task<List<MeetingWeek>> SeeArchive();
        Task<bool> AnyIsActiveWeek();
    }
}
