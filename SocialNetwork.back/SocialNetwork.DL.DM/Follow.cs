using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DL.DM
{
    public class Follow
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public String follower { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public String followed { get; set; }

        public DateTime createdAt { get; set; }
    }
}
