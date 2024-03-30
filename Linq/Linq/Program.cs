using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] names = { "Bill", "Will", "gill", "pill", "till", "Abhash" };
            int[] p = { 1, 2, 3, 4, 5 };
            int[] q = new int[5] { 2, 5, 6, 7, 8 };
            var myQuery = from name in names
                          where name.Contains("ll")
                          select name;
            foreach (var name in myQuery)
                Console.WriteLine(name);
            Student[] studentArray = {
                    new Student() { StudentID = 1, StudentName = "John", age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  age = 21 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , age = 21 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , age = 31 } ,
                    new Student() { StudentID = 6, StudentName = "Chris",  age = 17 } ,
                    new Student() { StudentID = 7, StudentName = "Rob",age = 17  } ,
                };
            Course[] courseArray =
            {
                new Course() { courseID = 1, courseName = "A", StudentID = 1 },
                new Course() { courseID = 2, courseName = "B", StudentID = 1 },
                new Course() { courseID = 3, courseName = "C", StudentID = 2 },
                new Course() { courseID = 4, courseName = "D", StudentID = 2 },
                new Course() { courseID = 5, courseName = "E", StudentID = 8 },
                new Course() { courseID = 6, courseName = "F" }
            };
            var students = from student in studentArray
                           where student.age > 12 && student.age < 20
                           select student;
            var bill = studentArray.Where<Student>(s => s.StudentName == "Bill");
            var studentOrdered = studentArray.OrderBy(s => s.StudentName);
            var studentOrdered_Name_Age_ID = studentArray.OrderBy(s => s.StudentName).ThenBy(s => s.age);
            var studentOrdered_ = studentArray.OrderByDescending(s => s.StudentName);
            var studentGroupBy = studentArray.GroupBy(s => s.age);
            //Console.WriteLine(JsonSerializer.Serialize(studentOrdered, new JsonSerializerOptions { WriteIndented = true }));
            //Console.WriteLine(JsonSerializer.Serialize(studentOrdered_, new JsonSerializerOptions { WriteIndented = true }));
            //Console.WriteLine(JsonSerializer.Serialize(studentGroupBy, new JsonSerializerOptions { WriteIndented = true }));
            //Console.WriteLine(JsonSerializer.Serialize<Student[]>(students.ToArray(),new JsonSerializerOptions { WriteIndented = true}));
            //Console.WriteLine(JsonSerializer.Serialize(bill)); 

            var studentRolledInAnyCourse = studentArray.Join(courseArray, (x) => x.StudentID, (y) => y.StudentID, (x, y) => new
            {
                studentID = x.StudentID,
                courseName = y.courseName
            });

            //Console.WriteLine(JsonSerializer.Serialize(studentRolledInAnyCourse));
            /*
           var letOuterStudent =  studentArray.Where((x) =>
            {
                var p = studentRolledInAnyCourse.Where(p => p.studentID == x.StudentID).ToList();
                return p.Count == 0;
            }).ToList();

            var letOuterCourse = courseArray.Where((x) =>
            {
                var p = studentRolledInAnyCourse.Where(p => p.studentID == x.StudentID).ToList();
                return p.Count == 0;
            }).ToList();

            Console.WriteLine(JsonSerializer.Serialize(letOuterStudent));
            Console.WriteLine(JsonSerializer.Serialize(letOuterCourse));
            
            var leftOuterGroupBy = studentArray.GroupJoin(courseArray, (x) => x.StudentID, (y) => y.StudentID, (x, y) => new
            {
                studentID = x.StudentID
            }).ToList();
            Console.WriteLine(JsonSerializer.Serialize(leftOuterGroupBy));
            */
            var leftOuterGroupByCourse = courseArray.GroupJoin(studentArray, (x) => x.StudentID, (y) => y.StudentID, (x, y) => new
            {

                studentID = x.StudentID,
                courseName = x.courseName
            }).SelectMany(x => x.courseName).ToList();
            Console.WriteLine(JsonSerializer.Serialize(leftOuterGroupByCourse));


            List<string> nameList = new List<string>() { "Abhash", "Kumar" };

            //merage all the sequene and flatten the result 
            var wholename = nameList.SelectMany(x => x);
            Console.WriteLine(JsonSerializer.Serialize(wholename));


            /*
            // cross join using select many
            var crossJoinStudentCourse = courseArray.SelectMany(c => courseArray, (x, y) =>
            new
            {
                studentId = x.StudentID,
                courseId = y.courseID
            });
            https://www.geeksforgeeks.org/cross-join-in-linq/
            */

            //cross join using special join condition
            var crossJoin = studentArray.Join(courseArray, (x) => true, (y) => true, (x, y) => new
            {
                studentID = x.StudentID,
                courseName = y.courseName
            });
            Console.WriteLine(JsonSerializer.Serialize(crossJoin));


            Console.WriteLine("**************************");

            Department d1 = new () { ID = 1, salary = 300};
            Department d2 = new () { ID = 2, salary = 100 };
            Department d3 = new () { ID = 3, salary = 200 };
            Department d4 = new () { ID = 4, salary = 400 };
            Department d5 = new () { ID = 5, salary = 500 };   
            Department d6 = new () { ID = 5, salary = 90 };
            Department d7 = new () { ID = 7, salary = 70 };

            Employee E1 = new Employee() { name = "Abhash", depts =  new() {d2, d5, d7 } };
            Employee E2 = new Employee() { name = "Kumar", depts = new () { d1, d2, d6, d7 } };

            ICollection<Employee> employees = new List<Employee>() { E1, E2 };
            var resultMax = employees.Select(e => new
            {
                name = e.name,
                dept = e.depts.Where(d => d.salary == e.depts.Max(e => e.salary)).FirstOrDefault()
            }).ToList();

            
            var resultFormatted = resultMax.Select(r => new
            {
                name = r.name,
                deptId = r.dept.ID,
                salary = r.dept.salary,
            }).ToList();
            Console.WriteLine(JsonSerializer.Serialize(resultFormatted));

            var resultSum = employees.Select(e => new
            {
                name = e.name,
                total = e.depts.Sum(e => e.salary)
            }).ToList();
            Console.WriteLine(JsonSerializer.Serialize(resultSum));

            var isAnyAgeGreaterThen25 = studentArray.Any(x => x.age > 25);
            Console.WriteLine(isAnyAgeGreaterThen25);

            var isAllStudentGreateThen15 = studentArray.All(x => x.age > 25);
            Console.WriteLine(isAllStudentGreateThen15);

            Console.WriteLine(isAllStudentGreateThen15.GetType());
           
        }
    }


    internal class Student
    {
        public int StudentID { get; set; }
        public String StudentName { get; set; }
        public int age { get; set; }
    }
    internal class Course
    {
        public int courseID { get; set; }
        public string courseName { get; set; }

        public int StudentID { get; set; }
    }

    internal class Department
    {
        public int ID { get; set; }
        public int salary { get; set;}
    }
    internal class Employee
    {
        public string name { get; set; }
        public List<Department> depts { get; set; }
    }
}
