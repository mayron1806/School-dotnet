using API.Models;

namespace API.Utils
{
    public static class ClassroomUtils
    {
        public static string GetClassroomName(string Type) {
            string shortName = ClassroomType.GetShortName(Type);
            var date = DateTime.Now;
            var year = date.Year;
            return $"{shortName}-{year}";
        }
    }
}