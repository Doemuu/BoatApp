using boatappapi.Enum;
using boatappapi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using static BCrypt.Net.BCrypt;

namespace boatappapi.Connector
{

    public class DbDoemuDataContext : DbContext
    {
        public DbDoemuDataContext(DbContextOptions<DbDoemuDataContext> options) :
            base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UseSerialColumns();

            var userList = CreateStaticUsers(builder);

            builder.Entity<UserModel>()
               .HasData(userList);

            var boatList = CreateStaticBoats();

            builder.Entity<BoatModel>()
                .HasData(boatList);
        }

        private IList<UserModel> CreateStaticUsers(ModelBuilder builder)
        {
            var userList = new List<UserModel>();

            userList.Add(new UserModel
            {
                Id = Guid.NewGuid(),
                Username = "Doemuu",
                Password = HashPassword("pw123456")
            });

            userList.Add(new UserModel
            {
                Id = Guid.NewGuid(),
                Username = "Admin",
                Password = HashPassword("abcd1234")
            });

            return userList;
        }

        private IList<BoatModel> CreateStaticBoats()
        {
            var boatList = new List<BoatModel>();
            //Create 10 random boats
            var values = System.Enum.GetValues(typeof(ColourEnum));

            for (int i = 0; i < 10; i++)
            {
                var rnd = new Random();

                var boat = new BoatModel
                {
                    Id = Guid.NewGuid(),
                    Name = "Boat" + i,
                    Description = "This is the Boat " + i + "."
                };

                if (rnd.Next(2) == 1)
                {
                    //has colour
                    var colour = (ColourEnum)values.GetValue(rnd.Next(values.Length));
                    boat.Colour = colour;

                    var colourString = System.Enum.GetName(typeof(ColourEnum), colour);
                    boat.Description += $" It's colour is: {colourString}";
                }

                boatList.Add(boat);
            }

            return boatList;
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BoatModel> Boats { get; set; }

    }
}
