using Amazon;
using Amazon.Runtime;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using SocialNetwork.BL.BC.Helpers;
using System;
using System.Collections.Generic;

namespace SocialNetwork.BL.BC.Services.Amazon
{
    public static class AmazonSES
    {
        static readonly string senderAddress = Configuration.AMAZON_SENDER_EMAIL;
        static readonly string subject = "Bienvenido a HablaPe";
 

        public static void sendEmail(String name, String receiverEmail, String linkActivation)
        {
            var credentials = new BasicAWSCredentials(Configuration.AMAZON_ACCESS_KEY, Configuration.AMAZON_SECRET_KEY);
            var region = RegionEndpoint.GetBySystemName(Configuration.AMAZON_REGION);

            using (var client = new AmazonSimpleEmailServiceClient(credentials, region))
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses =
                        new List<string> { receiverEmail }
                    },
                    Message = new Message
                    {
                        Subject = new Content(subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = Email.buildBody(name, linkActivation)
                            }
                        }
                    }
                };
                try
                {
                    var send = client.SendEmailAsync(sendRequest);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }
        }
    }
}
