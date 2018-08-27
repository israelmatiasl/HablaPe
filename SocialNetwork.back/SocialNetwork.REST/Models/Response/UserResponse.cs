using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class UserResponse
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String id { get; set; }
        public String name { get; set; }
        public String lastname { get; set; }
        public String photo { get; set; }
        public String url { get; set; }

        public UserResponse(String id, String name, String lastname, String photo, String url)
        {
            this.name = name;
            this.lastname = lastname;
            this.photo = photo;
            this.url = $"{url}/{id}";
        }
    }

    public class ListUserResponse
    {
        public Boolean success { get; set; }
        public List<UserResponse> users { get; set; }

        public ListUserResponse(List<UserResponse> users)
        {
            this.success = true;
            this.users = users;
        }
    }
}
