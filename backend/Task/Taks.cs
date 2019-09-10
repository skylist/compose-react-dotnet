using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.task {
    public class Task {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]
        public string _id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public string label { get; set; }
    }
}