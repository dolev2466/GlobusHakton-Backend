using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using globusHackthonBackendOpenSky.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace globusHackthonBackendOpenSky.Controllers
{
    public class DbController
    {
        private IMongoDatabase database; 

        private const string DB_URL =
            "mongodb+srv://globus:Aa123456@globus-dev.1ycxg.mongodb.net/<dbname>?retryWrites=true&w=majority";

        private const string DB_NAME = "globushackton";

        public DbController()
        {
            var client = new MongoClient(DB_URL);
            database = client.GetDatabase(DB_NAME);
            Console.WriteLine("MongoDb created" + database);
        }

        public async Task<IEnumerable<AircraftModel>> GetAll()
        {
            var airplanes= database.GetCollection<AircraftModel>("airplanes");
            Console.WriteLine(airplanes.ToString());
            return airplanes.Find(_=>true).ToList();
        }
        
        public async Task<IEnumerable<AircraftModel>> Get(string callSign)
        {
            var airplanes= database.GetCollection<AircraftModel>("airplanes");
            Console.WriteLine(airplanes.ToString());
            return airplanes.Find(airplane => airplane.CallSign == callSign).ToList();
        }
        
        public Task Update(string callSign, AircraftModel aircraft)
        {
            var airplanes= database.GetCollection<AircraftModel>("airplanes");
            Console.WriteLine(aircraft);
            var result = airplanes.FindOneAndReplace(
                airplane => airplane.CallSign == callSign,
                aircraft);
            Console.WriteLine(result);
            return null;
        }
        
        public Task Create(AircraftModel aircraft)
        {
            var airplanes= database.GetCollection<AircraftModel>("airplanes");
            Console.WriteLine(aircraft);
            airplanes.InsertOne(aircraft);
            return null;
        }
    }
}