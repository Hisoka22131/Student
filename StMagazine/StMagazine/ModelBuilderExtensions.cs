using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StMagazine.Interfaces;
using StMagazine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StMagazine
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Курсы
            Cours One = new Cours()
            {
                Id = 1,
                CoursNumber = 1
            };
            Cours Two = new Cours()
            {
                Id = 2,
                CoursNumber = 2
            };
            Cours Three = new Cours()
            {
                Id = 3,
                CoursNumber = 3
            };
            Cours Four = new Cours()
            {
                Id = 4,
                CoursNumber = 4
            };
            Cours Five = new Cours()
            {
                Id = 5,
                CoursNumber = 5
            };
            //предметы
            Item DM = new Item()
            {
                Id = 1,
                ItemName = "Дискретная математика"
            };
            Item MA = new Item()
            {
                Id = 2,
                ItemName = "Математический анализ"
            };
            Item Ph = new Item()
            {
                Id = 3,
                ItemName = "Физика"
            };
            Item Pr = new Item()
            {
                Id = 4,
                ItemName = "Программирование"
            };
            Item Al = new Item()
            {
                Id = 5,
                ItemName = "Алгебра"
            };
            //учителя
            Teacher teacherOne = new Teacher()
            {
                Id = 1,
                Name = "Елена",
                Surname = "Калинкова",
                PhoneNumber = "123456789",
                PhotoPath = "TeacherWomen1.jpg",
                ItemId = Pr.Id,
            };
            Teacher teacherTwo = new Teacher()
            {
                Id = 2,
                Name = "Татьяна",
                Surname = "Старчук",
                PhoneNumber = "123456789",
                PhotoPath = "TeacherWomen2.jpg",
                ItemId = DM.Id,
                // Item = MA
            };
            Teacher teacherThree = new Teacher()
            {
                Id = 3,
                Name = "Алиса",
                Surname = "Пикус",
                PhoneNumber = "123456789",
                PhotoPath = "TeacherWomen3.jpg",
                ItemId = Pr.Id,
                //Item = Pr
            };
            Teacher teacherFour = new Teacher()
            {
                Id = 4,
                Name = "Елена",
                Surname = "Белая",
                PhoneNumber = "123456789",
                PhotoPath = "TeacherWomen3.jpg",
                ItemId = MA.Id,
                //Item = Ph
            };
            Teacher teacherFive = new Teacher()
            {
                Id = 5,
                Name = "Василий",
                Surname = "Васильев",
                PhoneNumber = "123456789",
                PhotoPath = "TeacherMan.jpg",
                ItemId = Ph.Id,
                //Item = Al
            };
            //группы
            Group groupOne = new Group()
            {
                Id = 1,
                GroupName = "Прикладная математика",
                Year = 2022,
                Speciality = "Математическое моделирование",
                CoursId = One.Id,
                TeacherId = teacherOne.Id
            };
            Group groupTwo = new Group()
            {
                Id = 2,
                GroupName = "Наноэлектроника",
                Year = 2018,
                Speciality = "Инженер",
                CoursId = Four.Id,
                TeacherId = teacherTwo.Id
            };
            //студенты
            Student studentOne = new Student()
            {
                Id =1,
                Name = "Дмитрий",
                Surname = "Камбур",
                PhoneNumber = "+37377730701",
                PhotoPath = "StudentMan1.jpg",
                GroupId = groupOne.Id
            };
            Student studentTwo = new Student()
            {
                Id = 2,
                Name = "Кристина",
                Surname = "Зализняк",
                PhoneNumber = "+37377932123",
                PhotoPath = "StudentWomen1.jpg",
                GroupId = groupTwo.Id
            };
            //роли
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                    Name = "admin",
                    NormalizedName = "ADMIN"
                });
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@mail.ru",
                    NormalizedEmail = "ADMIN@MAIL.RU",
                    EmailConfirmed = true,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "123456"),
                    SecurityStamp = string.Empty
                });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            { 
                RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
            });
            modelBuilder.Entity<Cours>().HasData(One, Two, Three, Four, Five);
            modelBuilder.Entity<Item>().HasData(DM, Al, Pr, Ph, MA);
            modelBuilder.Entity<Group>().HasData(groupOne, groupTwo);
            modelBuilder.Entity<Teacher>().HasData(teacherOne, teacherThree, teacherTwo, teacherFour, teacherFive);
            modelBuilder.Entity<Student>().HasData(studentOne,studentTwo);
        }
    }
}
