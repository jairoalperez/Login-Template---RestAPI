using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginTemplate_RestAPI.Helpers
{
    public static class Messages
    {
        public static class API
        {
            public const string Working
                                = "The REST API is working good!";
            public const string JWTNotConfigured
                                = "JWT key is not configured";
            public const string Unauthorized
                                = "You are not authorized to do this request. (Token is missing or invalid)";
        }
    }
}