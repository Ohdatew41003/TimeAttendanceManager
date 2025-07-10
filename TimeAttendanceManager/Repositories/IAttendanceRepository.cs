using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendanceManager.Models;


namespace TimeAttendanceManager.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceRecord>> GetAllAsync();
        Task<AttendanceRecord> GetByIdAsync(string id);
        Task CreateAsync(AttendanceRecord record);
        Task UpdateAsync(string id, AttendanceRecord record);
        Task DeleteAsync(string id);
    }
}
