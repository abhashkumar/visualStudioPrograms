// when you class have so many properties which are optional in nature 

//Json serializer can only serilize public property or fields
// by defualt it serialize public property , and if you want to serialize public field use JSON include
// use json igone to ignore public propertiess

using BuilderPattern;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuilderPattern
{
    public class Student
    {
        [JsonInclude]
        public int id;
        [JsonInclude]
        public int age;
        [JsonInclude]
        public string Name;
        [JsonInclude]
        public string gender;
        [JsonInclude]
        public List<string> subjects;

        internal Student(StudentBuilder studentBuilder)
        {
            id = studentBuilder.id;
            age = studentBuilder.age;
            Name = studentBuilder.Name;
            gender = studentBuilder.gender;
            subjects = studentBuilder.subjects;
        }
        public void getStaudentData()
        {
            var data = JsonSerializer.Serialize<Student>(this);
            Console.WriteLine(data);
        }
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        StudentBuilder studentBuilder = new EnggStudentBuilder();
        studentBuilder.setGender("Male").setAge(26).setId(1).setName("Test Engg student").setSubject(); ;
        Student s = studentBuilder.Build();
        s.getStaudentData();
    }
}