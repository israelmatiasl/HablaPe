using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DL.DM
{
    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public String album { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public String post { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public String message { get; set; }

        public String url { get; set; }

        public DateTime createdAt { get; set; }
    }
}
