using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DL.DM
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public String user { get; set; }
        public String textbody { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
