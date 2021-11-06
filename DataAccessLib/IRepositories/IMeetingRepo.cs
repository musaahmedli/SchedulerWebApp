using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLib.IRepositories
{
    public interface IMeetingRepo
    {
        Task Add(Meeting meeting);
        Task<List<Meeting>> Get(int meetingDaysId);
        Task<List<Meeting>> GetMeetingOfEmployee(int employeeId,int meetingDaysId);
        Task<Meeting> GetById(int meetingId);
        Task Delete(int id);
        void Update(Meeting meeting);
    }
}
