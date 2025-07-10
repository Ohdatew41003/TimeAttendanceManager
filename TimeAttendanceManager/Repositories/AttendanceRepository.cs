using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using TimeAttendanceManager.Models;
using Microsoft.Extensions.Configuration;

namespace TimeAttendanceManager.Repositories
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly IMongoCollection<AttendanceRecord> _collection;

        public AttendanceRepository(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MongoDB");
            var dbName = config["MongoDB:Database"];

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _collection = database.GetCollection<AttendanceRecord>("AttendanceRecords");
        }
        public async Task<List<AttendanceRecord>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<AttendanceRecord> GetByIdAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(AttendanceRecord record) =>
            await _collection.InsertOneAsync(record);

        public async Task UpdateAsync(string id, AttendanceRecord record) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, record);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
