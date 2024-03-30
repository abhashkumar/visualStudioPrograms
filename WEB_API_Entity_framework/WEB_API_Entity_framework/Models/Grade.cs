using System.Text.Json.Serialization;

namespace WEB_API_Entity_framework.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        [JsonIgnore]
        public ICollection<Student> Students { get; set; }
    }
}
