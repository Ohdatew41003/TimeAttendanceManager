using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAttendanceManager.Models;
using TimeAttendanceManager.Repositories;

namespace TimeAttendanceManager.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _repo;

        public AttendanceService(IAttendanceRepository repo)
        {
            _repo = repo;
        }

        public Task<List<AttendanceRecord>> GetAll() => _repo.GetAllAsync();
        public Task<AttendanceRecord> GetById(string id) => _repo.GetByIdAsync(id);
        public Task Create(AttendanceRecord record) => _repo.CreateAsync(record);
        public Task Update(string id, AttendanceRecord record) => _repo.UpdateAsync(id, record);
        public Task Delete(string id) => _repo.DeleteAsync(id);
    }
}
