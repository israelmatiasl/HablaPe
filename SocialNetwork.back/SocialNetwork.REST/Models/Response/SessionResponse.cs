using Newtonsoft.Json;
using SocialNetwork.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class SessionResponse
    {
        public Boolean success { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public _SessionResponse session { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public MenuResponse menuResponse { get; set; }

        public SessionResponse(String name, String lastname, String nick, String birthday, String gender, String photo, String token)
        {
            success = true;
            session = new _SessionResponse(name, lastname, nick, birthday, gender, photo, token);
            menuResponse = new MenuResponse();
        }

        public SessionResponse(Boolean success, String message)
        {
            this.success = success;
            this.message = message;
        }
    }

    public class _SessionResponse
    {
        public String name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String lastname { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String nick { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String birthday { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String gender { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String photo { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public String token { get; set; }
        public _SessionResponse(String name, String lastname, String nick, String birthday, String gender, String photo, String token)
        {
            this.name = name;
            this.lastname = lastname;
            this.nick = nick;
            this.birthday = birthday;
            this.gender = gender;
            this.photo = photo;
            this.token = token;
        }
    }
}
