using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Helpers
{
    public class ConstantsResponse
    {
        public static String ERROR_HTTP_400 = "The request is not correct. See the details for more information.";
        public static String ERROR_HTTP_500 = "An internal error occurred on the server.";

        #region Login
        public const String bad_credentials = "Email or password are incorrect.";
        #endregion

        #region Register
        public const String register_success = "Has been successfully registered!";
        public const String register_failed = "Has been failed while trying register.";
        public const String email_exists = "There is already a user using this email";
        #endregion Register

        #region Token
        public const String token_invalid = "Token is invalid";
        #endregion

        #region Follow
        public const String FollowSuccess = "Following this user";
        public const String FollowFailed = "Already you are following this user";
        public const String UnFollowSuccess = "Stopped following this user";
        public const String UnFollowFailed = "Is not following this user";
        public const String NotFollow = "You're not following this user";
        #endregion Follow

        #region Post
        public const String PostGetFailed = "Have been occurred an error while get the posts";
        public const String PostSuccess = "Your post has been shared";
        public const String PostFailed = "Your post has not been shared";
        public const String PostNotFound = "Post not found";
        #endregion Post

        #region Profile
        public const String UserNotFound = "User not found";
        #endregion Profile
    }
}
