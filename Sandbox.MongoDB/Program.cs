// See https://aka.ms/new-console-template for more information
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Sandbox;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using Bogus;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Bogus.Extensions.UnitedKingdom;

//https://www.youtube.com/watch?v=69WBy4MHYUw]

string mode = Console.ReadLine();

var text = String.Empty;

MongoCrud db = new MongoCrud("MatchInfo");

MongoCrud carDb = new MongoCrud("UsedCarsDB");

db.DeleteRecords<Object>("Match");

if (mode == "delete")
{
    goto DeleteMode;
}

MatchModel match = new MatchModel()
{
	Home="Wolves",
	Away ="Southampton",
	FanInfo= new FanModel
	{
		HomeFanNumber = 50000,
		AwayFanNumber = 7000,
		BeerOnTap = "Carlsberg",
		BagsAllowed = false
	}
};

List<MatchModel> matchList = new();

Faker teamFaker = new();

Enumerable.Range(0, 15).ToList().ForEach(_ => carDb.InsertRecord("UsedCars", new UsedCar()
{
	Make = teamFaker.Vehicle.Manufacturer(),
	Model = teamFaker.Vehicle.Model(),
    Licence = teamFaker.Vehicle.GbRegistrationPlate(new DateTime(2002,10,10), DateTime.Now),
	LastMOT = teamFaker.Date.PastDateOnly()
}));

Enumerable.Range(0, 15).ToList().ForEach(_ => db.InsertRecord("Match", new MatchModel()
{
    Home = teamFaker.Company.CompanyName(),
    Away = teamFaker.Company.CompanyName(),
    FanInfo = new FanModel
    {
        HomeFanNumber = ConcurrentMatchMinuteRandom.Instance.Next(50000),
        AwayFanNumber = ConcurrentMatchMinuteRandom.Instance.Next(10000),
        BeerOnTap = teamFaker.Company.Bs(),
        BagsAllowed = ConcurrentMatchMinuteRandom.Instance.Next(2) != 0

    }
}));





var recs = db.LoadRecords<MatchModel>("Match");

//recs.ForEach(x => Console.WriteLine(x.Away));

var record = db.LoadRecordById<MatchModel>("Users", recs.First().ThisIsAnId);

Console.WriteLine(JsonSerializer.Serialize(record));

//Inserting anonymous object
//db.InsertRecord("Match", new
//{
//	Home = "Liverpool",
//	Away = "Everton",
//	Referee = "Mike Dean"
//});

DeleteMode:
Console.ReadLine();


//NoSQL data isn't normalized, you can add and remove fields at will, if they aren't 
//in the DB will just be returned as null
//NoSQL trades space for speed

public class UsedCar
{
    [BsonId]
    public Guid Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public string Licence { get; set; }
    public DateOnly LastMOT { get; set; }
}
public class MatchModel
{
	[BsonId]
	public Guid ThisIsAnId { get; set; }
	public string Home { get; set; }
	public string Away { get; set; }
	public FanModel FanInfo { get; set; }
}

public class FanModel
{
	public int HomeFanNumber { get; set; }
	public int AwayFanNumber { get; set; }
	public string BeerOnTap { get; set; }
	public bool BagsAllowed { get; set; }
}

public class MongoCrud
{
    private IMongoDatabase _db;

	public MongoCrud(string database)
	{
		//empty constructor connects to localhost
		var client = new MongoClient();
		//Will create db if doesn't exist
		_db = client.GetDatabase(database);
	}

	public void InsertRecord<T>(string table, T record)
	{
		var collection = _db.GetCollection<T>(table);
		collection.InsertOne(record);
	}

    public void DeleteRecords<T>(string table)
    {

        var collection = _db.GetCollection<T>(table);
		collection.DeleteMany(Builders<T>.Filter.Empty);
    }

    public List<T> LoadRecords<T>(string table)
	{
		var collection = _db.GetCollection<T>(table);
		return collection.Find(new BsonDocument()).ToList();
	}

	public T LoadRecordById<T>(string table, Guid id)
	{
        var collection = _db.GetCollection<T>(table);
		var filter = Builders<T>.Filter.Eq("_id", id);
        var filter2 = Builders<T>.Filter.Empty;

        var recs = collection.Find(filter).ToList();

        return collection.Find(filter2).First();
    }
}
