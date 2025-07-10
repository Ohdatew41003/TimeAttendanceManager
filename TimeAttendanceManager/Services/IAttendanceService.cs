using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendanceManager.Models;

namespace TimeAttendanceManager.Services
{
    public interface IAttendanceService
    {
        Task<List<AttendanceRecord>> GetAll();
        Task<AttendanceRecord> GetById(string id);
        Task Create(AttendanceRecord record);
        Task Update(string id, AttendanceRecord record);
        Task Delete(string id);
    }
}
