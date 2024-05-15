using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp2.Models
{
    public class SQLStudentRepository : IStudentRepository
    {
        private readonly StudentDBContext _context;
        public SQLStudentRepository(StudentDBContext context)
        {
            _context = context;
        }
        public Student AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student DeleteStudent(int studentId)
        {
            Student s = _context.Students.Find(studentId);
            if(s != null)
            {
                _context.Students.Remove(s);
                _context.SaveChanges();
            }
            return s;
        }

        public Student GetStudentById(int studentId)
        {
            return  _context.Students.Find(studentId);
        }

        public Student UpdateStudent(Student studentChanged)
        {
            var student = _context.Students.Attach(studentChanged);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return studentChanged;
        }
    }
}
