using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectSem3withTeam.Models
{
    public class ProjectSem3withTeamContext : DbContext
    {
        public ProjectSem3withTeamContext (DbContextOptions<ProjectSem3withTeamContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectSem3withTeam.Models.Subject> Subject { get; set; }
        public DbSet<ProjectSem3withTeam.Models.Teacher> Teacher { get; set; }
        public DbSet<ProjectSem3withTeam.Models.Student> Student { get; set; }
        public DbSet<ProjectSem3withTeam.Models.Mark> Mark { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>().HasData(
                new Subject
                {
                    Id = 1,
                    Name = "HTML",
                    Description = "Dễ học."
                },
                 new Subject
                 {
                     Id = 2,
                     Name = "Java",
                     Description = "Khá loằng ngoằng."
                 },
                 new Subject
                 {
                     Id = 3,
                     Name = "C#",
                     Description = "Dễ hơn java 1 chút."
                 },
                 new Subject
                 {
                     Id = 4,
                     Name = "PHP",
                     Description = "Dễ học."
                 },
                 new Subject
                 {
                     Id = 5,
                     Name = "ASP.NET",
                     Description = "Chưa xác định."
                 }
            );

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher
                {
                    Id = 1,
                    Name = "Xuân Hùng",
                    Email = "Xuanhung2401@gmail.com",
                    Phone = "012349876",
                    Avatar = "https://i.stack.imgur.com/EFHit.jpg?s=328&g=1"
                }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    RollNumber = "A001",
                    FirstName = "Trịnh",
                    LastName = "Việt",
                    Phone = "0349555602",
                    Email = "quocviet.hn98@gmail.com",
                    Avatar = "https://scontent.fhan5-2.fna.fbcdn.net/v/t1.0-9/43728863_918300711698721_2592658880836141056_n.jpg?_nc_cat=102&_nc_ht=scontent.fhan5-2.fna&oh=afbb930ed930627f4682eeef3d58c271&oe=5C725A56"
                },
                 new Student
                 {
                     RollNumber = "A002",
                     FirstName = "Thanh",
                     LastName = "Tùng",
                     Phone = "0349321324",
                     Email = "thanhtung.hn98@gmail.com",
                     Avatar = "https://scontent.fhan5-7.fna.fbcdn.net/v/t1.0-9/74230_571993326151147_1564071477_n.jpg?_nc_cat=100&_nc_ht=scontent.fhan5-7.fna&oh=d47a59698c8c56599511f5bfde14c90e&oe=5C88977B"
                 },
                 new Student
                 {
                     RollNumber = "A003",
                     FirstName = "Quế",
                     LastName = "Công",
                     Phone = "043243255",
                     Email = "quecong.hn98@gmail.com",
                     Avatar = "https://scontent.fhan5-6.fna.fbcdn.net/v/t1.0-9/42434595_2098209036910379_4231368300749127680_n.jpg?_nc_cat=107&_nc_ht=scontent.fhan5-6.fna&oh=60a1bf8f30a256768b5fd4af128e9932&oe=5C40E10E"
                 },
                 new Student
                 {
                     RollNumber = "A004",
                     FirstName = "Hương",
                     LastName = "Ly",
                     Phone = "0432443243",
                     Email = "huongly.hn98@gmail.com",
                     Avatar = "https://scontent.fhan5-1.fna.fbcdn.net/v/t1.0-9/23380126_514878092204816_4605254026945740300_n.jpg?_nc_cat=109&_nc_ht=scontent.fhan5-1.fna&oh=d20b108d93199e0adffa8f9a425d5dc7&oe=5C405AE8"
                 }
            );
            modelBuilder.Entity<Mark>().HasData(
                new Mark
                {
                    Id = 1,
                    StudentRollNumber = "A001",
                    SubjectId = 1,
                    SubjectMark = 63,
                    TeacherId = 1,
                }, 
                new Mark
                {
                    Id = 2,
                    StudentRollNumber = "A002",
                    SubjectId = 2,
                    SubjectMark = 45,
                    TeacherId = 1,
                },
                new Mark
                {
                    Id = 3,
                    StudentRollNumber = "A003",
                    SubjectId = 3,
                    SubjectMark = 85,
                    TeacherId = 1,
                },
                new Mark
                {
                    Id = 4,
                    StudentRollNumber = "A004",
                    SubjectId = 5,
                    SubjectMark = 95,
                    TeacherId = 1,
                }
            );
        }
    }
}
