using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp2.Models
{
    public class TestStudentRepository : IStudentRepository
    {

        public List<Student> DataSource()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 101, Name = "James", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 102, Name = "Smith", Branch = "ETC", Section = "B", Gender = "Male" },
                new Student() { StudentId = 103, Name = "David", Branch = "CSE", Section = "A", Gender = "Male" },
                new Student() { StudentId = 104, Name = "Sara", Branch = "CSE", Section = "A", Gender = "Female" },
                new Student() { StudentId = 105, Name = "Pam", Branch = "ETC", Section = "B", Gender = "Female" }
            };
        }
        public Student AddStudent(Student student)
        {
            int id = DataSource().Max(e => e.StudentId) + 1;
            student.StudentId = id;
            DataSource().Add(student);
            return student;
        }
        public Student DeleteStudent(int studentId)
        {
            Student s = DataSource().FirstOrDefault(e => e.StudentId == studentId);
            if (s != null)
                DataSource().Remove(s);
            return s;
        }

        public Student GetStudentById(int StudentId)
        {
            return DataSource().FirstOrDefault(e => e.StudentId == StudentId);
        }

        public Student UpdateStudent(Student studentChanged)
        {
            Student s = DataSource().FirstOrDefault(e => e.StudentId == studentChanged.StudentId);
            if (s != null)
            {
                s.Name = studentChanged.Name;
                s.Branch = studentChanged.Branch;
                s.Section = studentChanged.Section;
                s.Gender = studentChanged.Gender;
            }
            return s;
        }
    }
}
