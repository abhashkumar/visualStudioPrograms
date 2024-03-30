using System;

namespace expressionBody
{
    class Program
    {
        static void Main(string[] args)
        {
            location loc = new location("Delhi");
            Console.WriteLine(loc.Name);
            loc.Name = "Patlipuitra";
            Console.WriteLine(loc.Name);
            loc.MyProperty = "Patna";
            loc.getLocation();
            Console.WriteLine(loc.nameStartsWithP);

        }
    }
   public class location
    {
        private string locationName_;
        public location(string name) => locationName_ = name;
        public string Name
        {
            get => locationName_;
            set => locationName_ = value;
        }
        public  string MyProperty {
            get
            {
                return locationName_;
            }
            set
            {
                locationName_ = value;
            }
        }
        public  void getLocation() => Console.WriteLine($"Tearms and use {Name}");

        public bool nameStartsWithP => Name.StartsWith('P');

    }
}
