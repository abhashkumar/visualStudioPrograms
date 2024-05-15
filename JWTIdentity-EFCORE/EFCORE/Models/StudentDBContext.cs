using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWebApp2.Models
{
    public class StudentDBContext: IdentityDbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
