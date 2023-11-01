using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CashRegister.Models
{
    public class Order
    {
      
        private string _id;
        private List<string> _shakesId;
        private double _totalPrice;
        private string _clientName;
        private DateTime _creationTime;
        private DateTime _endTime;
        private List<Discount> _discounts;


        
        [BsonId, BsonElement("Id")]
        public string Id { get { return this._id; } }
        
        [BsonElement("OrderedShakes"), BsonRequired ]
        public List<string> ShakesId { get { return this._shakesId; } }

        [BsonElement("TotalPrice")]
        public double TotalPrice { get { return this._totalPrice; } }

        [BsonElement("ClientName"), BsonRequired]
        public string ClientName { get { return this._clientName; } }

        [BsonElement("CreationTime"), BsonRequired]
        public DateTime CreationTime { get { return this._creationTime; } }

        [BsonElement("EndTime")]
        public DateTime Endtime { get { return this._endTime; } }

        [BsonElement("Discounts"), BsonRequired]
        public List<Discount> Discount { get { return _discounts; } }


        public Order(List<string> shakesId, double totalPrice, string clientName, List<Discount> discounts)
        {
            _id = Guid.NewGuid().ToString();
            _shakesId = shakesId;
            _totalPrice = totalPrice;
            _clientName = clientName;
            _creationTime = DateTime.Now;
            _endTime = DateTime.Now.AddMinutes(1);
            _discounts = discounts;
        }

      
    }
}
