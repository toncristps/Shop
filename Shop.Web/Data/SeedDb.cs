namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using Helpers;
    using System.Collections.Generic;

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

            if (!this.context.Countries.Any())
            {
                var cities = new List<City>();
                cities.Add(new City { Name = "Cusco" });
                //cities.Add(new City { Name = "Bogotá" });

                this.context.Countries.Add(new Country
                {
                    Cities = cities,
                    Name = "Perú"
                });

                await this.context.SaveChangesAsync();
            }



            var user = await this.userHelper.GetUserByEmailAsync("toncrist@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Tony",
                    LastName = "Pari",
                    Email = "toncrist@gmail.com",
                    UserName = "toncrist@gmail.com",
                    PhoneNumber = "966719095",
                    Address = "A.P.V. Diego Quispe Ttito D-3",
                    CityId = this.context.Countries.FirstOrDefault().Cities.FirstOrDefault().Id,
                    City = this.context.Countries.FirstOrDefault().Cities.FirstOrDefault()

                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");

                var token = await this.userHelper.GenerateEmailConfirmationTokenAsync(user);
                await this.userHelper.ConfirmEmailAsync(user, token);

            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
	        if (!isInRole)
	        {
    	        await this.userHelper.AddUserToRoleAsync(user, "Admin");
	        }


            if (!this.context.Products.Any())
            {
                this.AddProduct("Lenteja Grande", user);
                this.AddProduct("Lenteja Bebe", user);
                this.AddProduct("Pallar Grande", user);
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
