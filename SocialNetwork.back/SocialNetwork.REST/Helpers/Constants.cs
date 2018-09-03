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

        public const string KEY_AES = "D|3H@8#_6-n%1$2S";
        public const string IV_AES = "D|3H@8#_6-n%1$2S";
        public const string SALT_AES = "insight123resultxyz";
        public const string PASS_AES = "SfdgGdETuvZafhDnJ";
    }
}
