using ClipShare.Core.Entities;
using ClipShare.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClipShare.DataAccess.Data
{
    public static class ContextInitializer
    {
        public static async Task InitializeAsync(Context context, 
            UserManager<AppUser> userManager, 
            RoleManager<AppRole> roleManager)
        {
            // Ensure the database is created. If it already exists, this will do nothing.
            if(context.Database.GetPendingMigrations().Count() > 0)
            {
                context.Database.Migrate();
            }

            if (!roleManager.Roles.Any())
            {
                foreach (var role in SD.Roles)
                {
                    await roleManager.CreateAsync(new AppRole { Name = role });
                }
            }

            if (!userManager.Users.Any())
            {
                var admin = new AppUser
                {
                    Name = "Samuel Boateng Gyebi",
                    Email = "sgboateng@hotmail.com",
                    UserName = "sgboateng",
                };

                await userManager.CreateAsync(admin, "P@$$w0rd*737#");
                await userManager.AddToRolesAsync(admin, [SD.AdminRole, SD.UserRole, SD.ModeratorRole]);


                var john = new AppUser
                {
                    Name = "John Doe",
                    Email = "johndoe@gmail.com",
                    UserName = "johndoe",
                };

                await userManager.CreateAsync(john, "Temp123$");
                await userManager.AddToRoleAsync(john, SD.UserRole);

                /*
                var johnChannel = new Channel
                {
                    Name = "JohnChannel",
                    About = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. ",
                    AppUserId = john.Id
                };
                context.Channel.Add(johnChannel);

                var peter = new AppUser
                {
                    Name = "Peter",
                    Email = "peter@example.com",
                    UserName = "peter",
                };

                await userManager.CreateAsync(peter, "Password123");
                await userManager.AddToRoleAsync(peter, SD.UserRole);

                var peterChannel = new Channel
                {
                    Name = "PeterChannel",
                    About = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. ",
                    AppUserId = peter.Id
                };
                context.Channel.Add(peterChannel);
                */

                var jane = new AppUser
                {
                    Name = "Jane Doe",
                    Email = "janedoe@gmail.com",
                    UserName = "janedoe",
                };

                await userManager.CreateAsync(jane, "@N0vell123");
                await userManager.AddToRoleAsync(jane, SD.ModeratorRole);

                /*
                // adding categories into our database
                var animal = new Category { Name = "Animal" };
                var food = new Category { Name = "Food" };
                var game = new Category { Name = "Game" };
                var nature = new Category { Name = "Nature" };
                var news = new Category { Name = "News" };
                var sport = new Category { Name = "Sport" };

                context.Category.Add(animal);
                context.Category.Add(food);
                context.Category.Add(game);
                context.Category.Add(nature);
                context.Category.Add(news);
                context.Category.Add(sport);

                await context.SaveChangesAsync();
                */
            }
        }
    }
}
