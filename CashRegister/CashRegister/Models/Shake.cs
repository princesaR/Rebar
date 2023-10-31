using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using CashRegister.Validation;
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

        [BsonElement("largePrice")]
        private double _largePrice;

        public string Name 
        { 
            get { return _name; }
            set
            {
                try
                {
                    ValidationCheck.IsShakeNameValid(value);
                }
                catch(Exception ex)
                { 
                    throw ex;  
                }
            }
        }
        public string Id { get { return _id; }  }
        public Shake(string id, string name, string description, double smallPrice, double mediumPrice, double largePrice)
        {
            _id = new Guid().ToString();
            this._name = name;
            this._description = description;
            _smallPrice = smallPrice;
            _mediumPrice = mediumPrice;
            _largePrice = largePrice;
        }
    }
}
