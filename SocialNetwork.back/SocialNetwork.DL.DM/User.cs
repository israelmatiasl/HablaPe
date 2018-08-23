using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.DL.DM
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String nick { get; set; }
        public String gender { get; set; }
        public DateTime birthday { get; set; }
        public DateTime joindate { get; set; }
        public String cellphone { get; set; }
        public String description { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public String photo { get; set; }
        public String status { get; set; }
        public Boolean verified { get; set; }
        public String role { get; set; }
    }
}
