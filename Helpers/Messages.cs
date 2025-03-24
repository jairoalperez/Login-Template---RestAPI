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

        public static class Database
        {
            public const string NoConnectionString
                                = "The connection string is missing";
            public const string ConnectionSuccess
                                = "Database connected successfully!";
            public const string ConnectionFailed
                                = "Couldn't connect to the database";
            public const string ProblemRelated
                                = "Problem related to the database call";
        }
    }
}