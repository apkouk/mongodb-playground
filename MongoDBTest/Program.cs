using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDBTest
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();

            Console.ReadLine();
        }

        static async Task MainAsync()
        {
            var connectionString = "mongodb+srv://cinevo:EB03HsKpqj0GQ0Bb@cinevo-jg8gu.mongodb.net/test";

            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("cinevo");


            FilterDefinition<Town> filter = Builders<Town>.Filter.Where(e => e.Name != "0");
            //var result = filter.Render(towns.DocumentSerializer,
            //    towns.Settings.SerializerRegistry).ToString();
            var towns = db.GetCollection<Town>("Towns").Find(filter).ToList<Town>();
        }

        internal class Town
        {
            [BsonId]
            public ObjectId _id { get; set; }

            [BsonElement]
            public string Name { get; set; }
            [BsonElement]
            public string Tag { get; set; }
            [BsonElement]
            public string Url { get; set; }
        }
        //static void Main(string[] args)
        //{

        //    try
        //    {
        //        MongoClient _client;
        //        MongoServer _server;
        //        MongoDatabase _database;

        //        var MongoDatabaseName = "cinevo";
        //        var MongoUsername = "cinevo";
        //        var MongoPassword = "cinevo";
        //        var MongoPort = 27017;
        //        var MongoHost = "cinevo-shard-00-00-jg8gu.mongodb.net";

        //        // Creating credentials  
        //        var credential = MongoCredential.CreateMongoCRCredential
        //        (MongoDatabaseName,
        //            MongoUsername,
        //            MongoPassword);

        //        // Creating MongoClientSettings  
        //        var settings = new MongoClientSettings
        //        {
        //            Credential = credential,
        //            Server = new MongoServerAddress(MongoHost, Convert.ToInt32(MongoPort))
        //        };
        //        _client = new MongoClient(settings);
        //        _server = _client.GetServer();
        //        _database = _server.GetDatabase(MongoDatabaseName);


        //        //var client = new MongoClient("mongodb://prosa:8734kg82RB!!@prosa-cluster-shard-00-00-ktrty.mongodb.net:27017,prosa-shard-00-01.mongodb.net:27017,prosa-shard-00-02.mongodb.net:27017/admin?ssl=true&replicaSet=prosa-cluster-shard-0&authSource=admin");



        //        //        var client = new MongoClient("mongodb://cinevo:cinevo@cinevo-shard-00-00-jg8gu.mongodb.net:27017,cinevo-shard-00-01-jg8gu.mongodb.net:27017,cinevo-shard-00-02-jg8gu.mongodb.net:27017/cinevo?replicaSet=cinevo-shard-0&ssl=true");
        //        //var database = client.ListDatabasesAsync().Result;
        //        //var collections = database.ListCollections();

        //        //var connectionString = @"mongodb://prosa:8734kg82RB!!@prosa-cluster-ktrty.mongodb.net/cinevo-test";
        //        //var db = new MongoClient(connectionString).ListDatabases();


        //        //var db = new MongoClient(mongoUrl).GetDatabase(dbname);
        //        //db.GetCollection<MyType>("myCollectionName");


        //        //var client = new MongoClient("mongodb://prosa:8734kg82RB!!@prosa-cluster-shard-00-00-ktrty.mongodb.net:27017,prosa-cluster-shard-00-01-ktrty.mongodb.net:27017,prosa-cluster-shard-00-02-ktrty.mongodb.net:27017/video?ssl=true&replicaSet=prosa-cluster-shard-0&authSource=admin");
        //        //var database = client.GetDatabase("video");


        //        //var client = new MongoClient("mongodb://prosa:8734kg82RB!!@prosa-cluster-shard-00-00-ktrty.mongodb.net:27017");
        //        //var database = client.ListDatabases();

        //        //var collections = database.ListCollections();

        //        // var collection = database.GetCollection<BsonDocument>("video");



        //        //var document = new BsonDocument
        //        //{
        //        //    {"Id","2"},
        //        //    {"Name","Testing"},
        //        //    {"Tag","testing"},
        //        //    {"Url", "http://localaladislknasdlknasd.com"}
        //        //};
        //        //collection.InsertOneAsync(document);

        //        //foreach (Town obj in towns)
        //        //{
        //        //    var document = new BsonDocument
        //        //    {
        //        //        {"Id",obj.Id},
        //        //        {"Name",obj.Name},
        //        //        {"Tag",obj.Tag},
        //        //        {"Url", obj.Url}
        //        //    };
        //        //    await collection.InsertOneAsync(document);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


    }

    
}
