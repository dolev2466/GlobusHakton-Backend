using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace globusHackthonBackendOpenSky.Models
{
    public class AircraftModel
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public string CallSign { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Altitude { get; set; }
    }
}