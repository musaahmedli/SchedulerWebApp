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
    public class MeetingWeekRepo : IMeetingWeekRepo
    {
        readonly Context context;
        public MeetingWeekRepo(Context context)
        {
            this.context = context;

        }
        
        public async Task<bool> AnyIsActiveWeek()
        {
            return await context.MeetingWeeks.AnyAsync();
        }
        public async Task Open(MeetingWeek week)
        {
            List<DaysOfWeek> days = context.DaysOfWeeks.ToList();
            List<MeetingDays> meetdays = new List<MeetingDays>();
            foreach (var item in days)
            {
                MeetingDays meetingDay = new MeetingDays();
                meetingDay.DayId = item.DayId;
                meetdays.Add(meetingDay);
            }
            week.MeetingDays = meetdays;
            await context.MeetingWeeks.AddAsync(week);
            await context.SaveChangesAsync();
        }

        public async Task Close()
        {
            MeetingWeek meetingWeek = await context.MeetingWeeks.FirstAsync();
            meetingWeek.IsActive = false;
            context.MeetingWeeks.Update(meetingWeek);
            context.SaveChanges();
        }

        public async Task<MeetingWeek> GetActiveWeekDays()
        {
            MeetingWeek meetingWeeks = await context.MeetingWeeks.Include(m=>m.MeetingDays).ThenInclude(m=>m.Days).FirstOrDefaultAsync();
            return meetingWeeks; 
        }

        public async Task<List<MeetingWeek>> SeeArchive()
        {
            List<MeetingWeek> archiveMeetingWeeks = await context.MeetingWeeks.IgnoreQueryFilters().ToListAsync();
            return archiveMeetingWeeks;
        }

    }
}
