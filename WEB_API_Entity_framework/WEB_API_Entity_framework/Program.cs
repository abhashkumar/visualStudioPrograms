using WEB_API_Entity_framework.Contexts;
using WEB_API_Entity_framework.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        using (var context = new SchoolContext())
        {
            
            var studentsNames = context.Students.Select(x => x.Name).ToArray();
            Console.WriteLine(JsonSerializer.Serialize(studentsNames));

            var studentsNames_ = context.Students.ToArray();
            Console.WriteLine(JsonSerializer.Serialize(studentsNames_));
            
            var studentWithGrade = context.Students.Include(s => s.Grade).ToArray();
            Console.WriteLine(JsonSerializer.Serialize(studentWithGrade));
            
            var studentWithGrade_ = context.Students
                        .FromSql($"Select * from Students where Name like '%ill%'")
                        .Include(s => s.Grade)
                        .ToArray();
            Console.WriteLine(JsonSerializer.Serialize(studentWithGrade_));

            //running a stored procedure
            var studentProcedure = context.Students.FromSql($"exec GetStudents Gill").ToArray();
            Console.WriteLine(JsonSerializer.Serialize(studentProcedure));

            // grade and student table is already connected with primary key and foreign key relationship and ids will be created automatically
            /*
            Grade g = new Grade()
            {
                GradeName = "3",
                Section = "A"
            };
            Student s = new Student()
            {
                Name = "Nelson",
                Grade = g
            };
            context.Add(s);
            context.SaveChanges();
            */
        }
        
        app.Run();
    }
}