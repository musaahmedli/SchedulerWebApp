using DataAccessLib.IRepositories;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Repositories
{
    public class MeetinDaysRepo : IMeetingDaysRepo
    {
        readonly Context context;
        public MeetinDaysRepo(Context context)
        {
            this.context = context;
        }
        public async Task<List<MeetingDays>> GetActiveWeekDays()
        {
            List<MeetingDays> meetingDays = await context.MeetingDays.ToListAsync();
            return meetingDays;
        }
    }
}
