using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;


namespace TimeAttendanceWinForms.Mongo
{
    public class MongoDbContext
    {
        public IMongoDatabase Database { get; }

        public MongoDbContext()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config["MongoDB:ConnectionString"];
            var dbName = config["MongoDB:Database"];

            var client = new MongoClient(connectionString);
            Database = client.GetDatabase(dbName);
        }
    }
}
