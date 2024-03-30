using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

//try to see why you should use equatable rather then compare in hash set understand the difference 

namespace Equality
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Name = "Jay", Age = 25 };
            Person p2 = p1;
            Person p3 = new Person { Name = "Jay", Age = 25 };

            Console.WriteLine(p1.Equals(p2));  // True
            Console.WriteLine(p1 == p2);       // True

            Console.WriteLine(p1.Equals(p3));  // True
            Console.WriteLine(p1 == p3);       // True

            var people = new List<Person> { p1, p3 };

            Console.WriteLine(p1.Equals(p3));
           // Console.WriteLine(people.Distinct(new PersonCompare()).Count());
            //Console.WriteLine(new PersonCompare().Equals(p1, p3));
            HashSet<Person> set = new HashSet<Person>();
            set.Add(p1);
            set.Add(p3);
            //Console.WriteLine(set.Distinct(new PersonCompare()).Count());
            Console.WriteLine(set.Count);
        }
    }
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }

    //    public override bool Equals(object obj)
    //    {
    //        var other = obj as Person;

    //        if (ReferenceEquals(other,null))
    //            return false;

    //        if (Name != other.Name || Age != other.Age)
    //            return false;

    //        return true;
    //    }

    //    public static bool operator ==(Person x, Person y)
    //    {
    //        return x.Equals(y);
    //    }

    //    public static bool operator !=(Person x, Person y)
    //    {
    //        return !(x == y);
    //    }

    //    public override int GetHashCode()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public class Person : IEquatable<Person>
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public bool Equals(Person other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Name.Equals(other.Name) && Age.Equals(other.Age);
        }
        public static bool operator ==(Person x, Person y)
        {
            return x.Equals(y);
        }

        public static bool operator !=(Person x, Person y)
        {
            return !(x == y);
        }
        public override int GetHashCode()
        {
            int hashName = Name == null ? 0 : Name.GetHashCode();
            int hashAge = Age.GetHashCode();

            return hashName ^ hashAge;
        }
    }
    //public class Person
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //}
    //public class PersonCompare : IEqualityComparer<Person>
    //{
    //    public bool Equals(Person x, Person y)
    //    {
    //        if (ReferenceEquals(x, null))
    //            return false;
    //        if (ReferenceEquals(y, null))
    //            return false;
    //        return x.Name == y.Name && x.Age == y.Age;
    //    }

    //    public int GetHashCode([DisallowNull] Person obj)
    //    {
    //        int hashName = obj.Name == null ? 0 : obj.Name.GetHashCode();
    //        int hashAge = obj.Age.GetHashCode();

    //        return hashName ^ hashAge;
    //    }
    //}
}
