using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BL.BC
{
    public class Configuration
    {
        public const String AMAZON_REGION = "us-east-1";
        public const String AMAZON_ACCESS_KEY = "AKIAJAAOKAZ3F6IPDB5A";
        public const String AMAZON_SECRET_KEY = "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";
        public const String AMAZON_SENDER_EMAIL = "socialnetworkingperu@gmail.com";
        public const String AMAZON_S3_BUCKET = "socialnetwork.app";
        public const String ALLOWED_FILE_EXTENSIONS = "jpg,jpeg,png,gif,doc,pdf,zip";

        public static String GenerateLongIdentifier  => $"{Guid.NewGuid().ToString().Replace("-", "")}{DateTime.Now.Ticks.ToString()}";
    }
}
