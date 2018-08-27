using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Helpers
{
    public class Constants
    {
        public static String key_jwt = "aquivaunaclavesupersecreta";
        public static String issuer_jwt = "http://www.domainname.com";
        public static String audience_jwt = "http://www.domainname.com";
        public static String key_jwt_activation = "aquivaotraclavesupersecreta";
        public static String issuer_jwt_activation = "http://www.domainname.com";
        public static String audience_jwt_activation = "http://www.domainname.com";


        public const int pageSizePosts = 3;
        public const int pageSizeMessages = 8;
    }
}
