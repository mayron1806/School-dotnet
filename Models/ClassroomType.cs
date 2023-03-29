namespace API.Models
{
    public static class ClassroomType
    {
        public const string MATHEMATICS = "MATHEMATICS";
        public const string PHYSICAL = "PHYSICAL";
        public const string CHEMICAL = "CHEMICAL";
        public const string GEOGRAPHY = "GEOGRAPHY";
        public const string HISTORY = "HISTORY";

        public static bool IsValid(string value) 
        {
            switch (value) {
                case MATHEMATICS:
                case PHYSICAL:
                case CHEMICAL:
                case GEOGRAPHY:
                case HISTORY:
                    return true;
                default:
                    return false;
            }
        }
        public static string GetShortName(string value) {
             switch (value) {
                case MATHEMATICS:
                    return "Math";
                case PHYSICAL:
                    return "Physic";
                case CHEMICAL:
                    return "Chemical";
                case GEOGRAPHY:
                    return "Gegraphy";
                case HISTORY:
                    return "History";
                default:
                    throw new ArgumentOutOfRangeException("Invalid value: " + value);
            }
        }
    }
}