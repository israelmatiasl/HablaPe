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
        public String name { get; set; }
        public String lastname { get; set; }
        public String photo { get; set; }
        public String url { get; set; }

        public UserResponse(String name, String lastname, String photo, String url)
        {
            this.name = name;
            this.lastname = lastname;
            if (String.IsNullOrEmpty(photo))
            {
                this.photo = "www.default-image.com";
            }
            else
            {
                this.photo = photo;
            }
            this.url = url;
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
