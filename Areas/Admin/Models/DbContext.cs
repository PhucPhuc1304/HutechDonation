using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Web_Donation.Models;

namespace Web_Donation.Areas.Admin.Models
{
    public class DbContext
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        public DbContext(IConfiguration config)
        {
            _client = new MongoClient(config.GetConnectionString("MongoDB"));
            _database = _client.GetDatabase("Web-HDBank");
        }

        public IMongoCollection<Account> GetAccountCollection()
        {
            return _database.GetCollection<Account>("account");
        }

        public IMongoCollection<ProjectModel> GetProductCollection()
        {
            return _database.GetCollection<ProjectModel>("Product");


        }
        public IMongoCollection<Details> GetDetailsCollection()
        {
            return _database.GetCollection<Details>("Details");
        }
    }
}
