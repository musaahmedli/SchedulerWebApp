using DataAccessLib.IRepositories;
using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.Repositories
{
    public class MeetingRepo : IMeetingRepo
    {
        readonly Context _context;
        public MeetingRepo(Context context)
        {
            _context = context;
        }
        

        public async Task Delete(int id)
        {
            Meeting meeting = await _context.Meetings.FindAsync(id);
            meeting.IsDeleted = true;
            _context.Update(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Meeting>> Get(int meetingDaysId)
        {
            return  await _context.Meetings.Where(m=>m.MeetingDaysId ==meetingDaysId).ToListAsync(); 
        }

        public async Task<Meeting> GetById(int meetingId)
        {
            return await _context.Meetings.FindAsync(meetingId);
        }

        public async Task<List<Meeting>> GetMeetingOfEmployee(int employeeId,int meetingDaysId)
        {


            List<Meeting> meeting = await _context.Meetings.ToListAsync();
            List<Meeting> neededMeetings = new List<Meeting>();
            foreach (var item in meeting)
            {
                if (item.MeetingDaysId == meetingDaysId) 
                {
                    foreach (var em in item.EmployeeMeetings)
                    {
                        if (em.EmployeeId == employeeId)
                        {
                            neededMeetings.Add(item);
                        }
                    }
                }
                
            }
            return neededMeetings;
        }
        public async Task Add(Meeting meeting)
        {
            List<EmployeeMeeting> employeeMeetings = new List<EmployeeMeeting>();
            foreach (var item in meeting.EmployeeIdList)
            {
                EmployeeMeeting employeeMeeting = new EmployeeMeeting();
                Employee employee = await _context.Employees.FindAsync(item);
                employeeMeeting.EmployeeId = employee.EmployeeId;
                employeeMeetings.Add(employeeMeeting);
            }
            meeting.EmployeeMeetings = employeeMeetings;
            _context.Meetings.Add(meeting);

            await _context.SaveChangesAsync();
        }

        public void Update(Meeting meeting)
        {

            List<EmployeeMeeting> employeeMeetings = new List<EmployeeMeeting>();

            foreach(var item in meeting.EmployeeIdList)
            {
                if (_context.EmployeeMeetings.Any(m => m.EmployeeId == item && m.MeetingId==meeting.MeetingId)) continue;
                EmployeeMeeting employeeMeeting = new EmployeeMeeting();
                employeeMeeting.EmployeeId = item;
                employeeMeetings.Add(employeeMeeting);
            }
            meeting.EmployeeMeetings = employeeMeetings;
            _context.Meetings.Update(meeting);
            if (meeting.StartTime == default && meeting.EndTime==default)
            {
                _context.Entry(meeting).Property("StartTime").IsModified = false;
                _context.Entry(meeting).Property("EndTime").IsModified = false;
            }
            
            if (meeting.MeetingDaysId == 0)
            {
                _context.Entry(meeting).Property("MeetingDaysId").IsModified = false;
            }
            
            _context.SaveChanges();
        }
    }
}
