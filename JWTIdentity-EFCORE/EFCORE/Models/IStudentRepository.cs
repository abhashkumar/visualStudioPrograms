using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp2.Models
{
    public interface IStudentRepository
    {
        public Student GetStudentById(int StudentId);
        public Student AddStudent(Student student);
        public Student UpdateStudent(Student studentChanged);
        public Student DeleteStudent(int studentId);
    }
}
