using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CashRegister.Models
{
    public class Shake
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        private string _id;

        [BsonElement("name")]
        private string _name;

        [BsonElement("description")]
        private string _description;

        [BsonElement("smallPrice")]
        private double _smallPrice;

        [BsonElement("mediumPrice")]
        private double _mediumPrice;

        [BsonElement("lsargePrice")]
        private double _largePrice;

        public string Name { get { return _name; } }
        public string Id { get { return _id; } set { _id = value; } }
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
