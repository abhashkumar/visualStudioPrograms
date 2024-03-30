namespace WEB_API_Entity_framework.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentGradeId { get; set; }
        public Grade Grade { get; set; }
    }
}
