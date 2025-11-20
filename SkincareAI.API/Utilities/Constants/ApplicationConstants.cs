namespace SkincareAI.API.Utilities.Constants
{
    public static class ApplicationConstants
    {
        public const string ApplicationName = "SkincareAI API";
        public const string Version = "1.0.0";

        public static class Pagination
        {
            public const int DefaultPageSize = 20;
            public const int MaxPageSize = 100;
        }

        public static class Validation
        {
            public const int MaxConcerns = 10;
            public const int MaxSymptoms = 15;
            public const int MaxNotesLength = 500;
        }
    }
}