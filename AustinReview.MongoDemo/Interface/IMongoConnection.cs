using MongoDB.Driver;

namespace AustinReview.MongoDemo.Interface;

public interface IMongoConnection
{
    public MongoClient MongoDBClient { get; set; }
    public IMongoDatabase DatabaseName { get; set; }
}