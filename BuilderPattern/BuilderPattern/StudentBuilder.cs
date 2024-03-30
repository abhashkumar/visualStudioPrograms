namespace BuilderPattern
{
    public abstract class StudentBuilder
    {
        internal int id;
        internal int age;
        internal string Name;
        internal string gender;
        internal List<string> subjects;

        public StudentBuilder setId(int id)
        {
            this.id = id;
            return this;
        }
        public StudentBuilder setAge(int age)
        {
            this.age = age;
            return this;
        }
        public StudentBuilder setName(string name)
        {
            this.Name = name;
            return this;
        }
        public StudentBuilder setGender(string gender)
        {
            this.gender = gender;
            return this;
        }

        public abstract StudentBuilder setSubject();

        public Student Build() => new Student(this);
    }

    public class EnggStudentBuilder : StudentBuilder
    {
        public override StudentBuilder setSubject()
        {
            subjects = new List<string> { "A", "B", "C" };
            return this;
        }
    }

    public class MBAStudentBuilder : StudentBuilder
    {
        public override StudentBuilder setSubject()
        {
            subjects = new List<string> { "D", "E", "F" };
            return this;
        }
    }

}
