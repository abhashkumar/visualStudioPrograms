using AutoMapper;
using System;

namespace Automappers
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Employee, EmployeeDTO>()
                     .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Dept, act => act.MapFrom(src => src.Department))
                );
            //Creating the source object
            Employee emp = new Employee
            {
                Name = "James",
                Salary = 20000,
                Address = "London",
                Department = "IT"
            };

            //Using automapper
            var mapper = new Mapper(config);
            var empDTO = mapper.Map<EmployeeDTO>(emp);
            //OR
            //var empDTO2 = mapper.Map<Employee, EmployeeDTO>(emp);
            Console.WriteLine("Name:" + empDTO.FullName + ", Salary:" + empDTO.Salary + ", Address:" + empDTO.Address + ", Department:" + empDTO.Dept);
            Console.ReadLine();
        }
    }
    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
    }
    public class EmployeeDTO
    {
        public string FullName { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }
        public string Dept { get; set; }
    }
}
