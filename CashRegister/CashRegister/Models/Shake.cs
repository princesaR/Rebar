using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CashRegister.Models
{
    public class Shake
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private readonly string _id;

        [BsonElement("Name")]
        private string _name;

        [BsonElement("Description")]
        private string _description;

        [BsonElement("smallPrice")]
        private double _smallPrice;

        [BsonElement("mediumPrice")]
        private double _mediumPrice;

        [BsonElement("largePrice")]
        private double _largePrice;

        public string Name { get { return _name; } }
        public string Id { get { return _id; } }
        public Shake(string id, string name, string description, double smallPrice, double mediumPrice, double largePrice)
        {
            _id = id;
            this._name = name;
            this._description = description;
            _smallPrice = smallPrice;
            _mediumPrice = mediumPrice;
            _largePrice = largePrice;
        }
    }
}
