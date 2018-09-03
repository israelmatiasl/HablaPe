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
        public const String BadCredentials = "Email o contraseña incorrectos";
        #endregion

        #region Register
        public const String RegisteredSucceed = "Se ha registrado satisfactoriamente. Se ha enviado un enlace a su email para poder verificar su cuenta";
        public const String RegisteredFailed = "Ha ocurrido un error al momento de registrar. Por favor inténtelo más tarde.";
        public const String EmailExists = "Ya existe un usuario registrado con el mismo email. Intente ingresar otro email.";
        #endregion Register

        #region Token
        public const String TokenInvalid = "Token is invalid";
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
