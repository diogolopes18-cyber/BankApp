using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Bank
{
    public class StoreClientInfo
    {
        public static void Main()
        {
            //Create new MongoDB instance and create a new database with the name we pass as a class parameter
            MongoDbConnection db = new MongoDbConnection("BankDatabase");

            //The second parameter will be a object of class PersonInformation which formats the document inside the 
            //users collection as we define it
            db.InsertData("Users", new PersonInformation { FirstName = OpenAccount.Details(), Age = 30});
        }
    }

    //Defines how data is inserted into the document
    public class PersonInformation
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
    }

    public class MongoDbConnection
    {
        private IMongoDatabase db;

        //When using the same name as the class we define a class constructor
        public MongoDbConnection(string database)
        {
            //Create a new MongoDB Client
            var client = new MongoClient();

            //Initializes the db property and connects to the database
            db = client.GetDatabase(database);
        }

        public void InsertData<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    }
}
