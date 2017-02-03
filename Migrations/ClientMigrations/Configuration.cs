namespace lab5.Migrations.ClientMigrations
{
    using Models.CityModel;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lab5.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ClientMigrations";
        }

        protected override void Seed(lab5.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Province.AddOrUpdate(f => new { f.ProvinceCode, f.ProvinceName },
                getProvinces());
            context.Cities.AddOrUpdate(p => new { p.CityId, p.CityName, p.Population },
                getCities(context));
            context.SaveChanges();
        }

        private City[] getCities(Models.ApplicationDbContext context)
        {
            List<City> cities = new List<City>()
            {
                new City()
                {
                    CityName = "London",
                    Population = 366150,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "Ontario").ProvinceCode
                },
                new City()
                {
                    CityName = "Toronto",
                    Population = 2615000,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "Ontario").ProvinceCode
                },
                new City()
                {
                    CityName = "Ottawa",
                    Population = 883391,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "Ontario").ProvinceCode
                },

                new City()
                {
                    CityName = "Calgary",
                    Population = 1097000,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "Alberta").ProvinceCode
                },
                new City()
                {
                    CityName = "Edmonton",
                    Population = 812200,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "Alberta").ProvinceCode
                },
                new City()
                {
                    CityName = "Red Deer",
                    Population = 91000,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "Alberta").ProvinceCode
                },

                new City()
                {
                    CityName = "Victoria",
                    Population = 80000,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "British Columbia").ProvinceCode
                },
                new City()
                {
                    CityName = "Vancouver",
                    Population = 600000,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "British Columbia").ProvinceCode
                },
                new City()
                {
                    CityName = "Surrey",
                    Population = 510000,
                    ProvinceCode = context.Province.FirstOrDefault(f => f.ProvinceName == "British Columbia").ProvinceCode
                },
            };
            return cities.ToArray();
        }


        private Province[] getProvinces()
        {
            List<Province> provinces = new List<Province>
            {
                new Province() {
                    ProvinceCode = "BC",
                    ProvinceName = "British Columbia"
                },
                new Province() {
                    ProvinceCode = "AB",
                    ProvinceName = "Alberta"
                },
                new Province() {
                    ProvinceCode = "ON",
                    ProvinceName = "Ontario"
                }

            };
            return provinces.ToArray();
        }
    }
}
