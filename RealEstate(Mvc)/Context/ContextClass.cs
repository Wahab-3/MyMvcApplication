
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RealEstate_Mvc_.Models.Entities;
using RealEstateMvc.Models.Entities;
using System;
using System.Data.SqlClient;

namespace RealEstate_Mvc_.Context
{
    public class ContextClass : DbContext
    {
        public ContextClass(DbContextOptions<ContextClass> opt) : base(opt)
        {

        }

        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Owner> Owners => Set<Owner>();
        public DbSet<Staff> Staffs => Set<Staff>();
        public DbSet<Transaction> Transactions => Set<Transaction>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Staff>().HasData(new Staff
            {
                Email = "SuperAdmin@gmail.com",
                Address = "Abk",
                FirstName = "AbdulWahab",
                LastName = "Jokosenumi",
                PhoneNumber = 08080954101,
                Gender = RealEstateMvc.Models.Enum.Gender.Male,
                RoleName = "SuperAdmin",
                DeletedBy = "Wahab",
                StaffTagNumber = "SuperAdmin001",
                Age = 17,
                Id = "001",
                Dob = new DateTime(2007, 02, 14, 14, 30, 0)

            });
            builder.Entity<Owner>().HasData(new Owner
            {
                Email = "SuperAdmin@gmail.com",
                DeletedBy = "Wahab",
                Id = "001",
                IsAvailable = true,
                StaffNumber = "Staff001",

            });

            builder.Entity<User>().HasData(new User
            {

                Password = BCrypt.Net.BCrypt.HashPassword("SuperAdmin"),
                Email = "SuperAdmin@gmail.com",
                CreatedBy = "Wahab",
                FullName = "JokosenumiAbdulWahab",
                Id = "Super001",
            });


            builder.Entity<Role>().HasData(new Role
            {
                Id = "abcd",
                Name = "Superadmin",
                CreatedBy = "Wahab",
                Description = "SuperAdmin on the app",
            });
            builder.Entity<UserRole>().HasData(new UserRole
            {
                Id = "qwer",
                UserId = "Super001",
                RoleId = "abcd",

            });
            builder.Entity<Category>().HasData(new Category
            {
              CreatedBy = "Wahab",
              Description = "Well Completed Building",
              Id = "abcd",
              Name = "Completed Buildings"
              

            }); 
            builder.Entity<Category>().HasData(new Category
            {
              CreatedBy = "Wahab",
              Description = "Landed Property",
              Id = "abcd123",
              Name = "Landed Property"
              

            }); 
            builder.Entity<Category>().HasData(new Category
            {
              CreatedBy = "Wahab",
              Description = "unCompleted Building",
              Id = "abcd0987",
              Name = "unCompleted Buildings"
              

            });


        }





    }
}