using Newtonsoft.Json;
using SocialNetwork.DL.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class PreSessionResponse
    {
        public String name { get; set; }
        public String lastname { get; set; }
        public String nick { get; set; }
        public String birthday { get; set; }
        public String gender { get; set; }
        public String photo { get; set; }
        public String token { get; set; }
        public PreSessionResponse(String name, String lastname, String nick, String birthday, String gender, String photo, String token)
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

    public class SessionResponse
    {
        public Boolean success { get; set; }
        public PreSessionResponse session { get; set; }
        public SessionResponse(PreSessionResponse session)
        {
            this.success = true;
            this.session = session;
        }
    }
}
