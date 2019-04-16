﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Identity.Model;
using static User.Identity.Model.AppUser;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using User.Identity.Manager;

namespace User.Identity.Store
{
    public class DbInitialize : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        private async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new CustomRoleStore(context);
                var manager = new ApplicationRoleManager(store);
                var role = new AppRole { Name = "Admin" };
                await manager.CreateAsync(role);
                var roleUser = new AppRole { Name = "User" };
                await manager.CreateAsync(roleUser);
            }
            if(!context.Users.Any(u=>u.UserName=="admin"))
            {
                var store = new CustomUserStore(context);
                var manager = new ApplicationUserManager(store);
                var user = new AppUser
                {
                    FirstName = "admin",
                    LastName = "admin",
                    UserName = "admin",
                    Email = "admin@admin.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };
                await manager.CreateAsync(user, "1234567890");

                await manager.AddToRoleAsync(user.Id, "Admin");
                await manager.AddToRoleAsync(user.Id, "User");


            }

            if (!context.Users.Any(u => u.UserName == "user"))
            {
                var store = new CustomUserStore(context);
                var manager = new ApplicationUserManager(store);
                var user = new AppUser
                {
                    FirstName = "user1",
                    LastName = "user1",
                    UserName = "user1",
                    Email = "user1@user1.com",
                    EmailConfirmed = true,
                    PhoneNumber = "0123456789",
                    PhoneNumberConfirmed = true
                };
                await manager.CreateAsync(user, "1234567890");

                await manager.AddToRoleAsync(user.Id, "user");
                await manager.AddToRoleAsync(user.Id, "User");
            }
        }
        protected override void Seed(ApplicationDbContext context)
        {

            Task.Run(async () => { await SeedAsync(context); }).Wait();

            base.Seed(context);
        }
    }

    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base()
        {
            if (!Database.Exists())
            {
                Database.SetInitializer<ApplicationDbContext>(new DbInitialize());
            }
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
