﻿namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");


            var user = await this.userHelper.GetUserByEmailAsync("toncrist@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Tony",
                    LastName = "Pari",
                    Email = "toncrist@gmail.com",
                    UserName = "toncrist@gmail.com",
                    PhoneNumber = "966719095"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
	        if (!isInRole)
	        {
    	        await this.userHelper.AddUserToRoleAsync(user, "Admin");
	        }


            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone x", user);
                this.AddProduct("Magic Mouse", user);
                this.AddProduct("IWachy Series 4", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name,User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }

}
