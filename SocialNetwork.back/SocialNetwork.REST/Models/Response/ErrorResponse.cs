using System;

namespace SocialNetwork.Rest.Models.Response
{
    public class ErrorResponse
    {
        public String message { get; set; }
        public Object details { get; set; }

        public ErrorResponse(String message)
        {
            this.message = message;
        }

        public ErrorResponse(String message, Object details)
        {
            this.message = message;
            this.details = details;
        }

    }
}
