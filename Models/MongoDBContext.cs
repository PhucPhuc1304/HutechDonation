using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Web_Donation.Models;

public class MongoDBContext
{
    private IMongoClient _client;
    private IMongoDatabase _database;

    public MongoDBContext(IConfiguration config)
    {
        _client = new MongoClient(config.GetConnectionString("MongoDB"));
        _database = _client.GetDatabase("Web-HDBank");
    }

    public IMongoCollection<Product> GetProductCollection()
    {
        return _database.GetCollection<Product>("Product");
    }
    public IMongoCollection<Details> GetDetailsCollection()
    {
        return _database.GetCollection<Details>("Details");
    }
}
