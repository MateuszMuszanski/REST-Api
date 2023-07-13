using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext restaurantDbContext;
        public RestaurantSeeder(RestaurantDbContext _restaurantDbContext)
        {
            restaurantDbContext = _restaurantDbContext;
        }
        public void Seed()
        {
            if (restaurantDbContext.Database.CanConnect())
            {
                if (!restaurantDbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    restaurantDbContext.Restaurants.AddRange(restaurants);
                    restaurantDbContext.SaveChanges();
                }
            }
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "whaveter",
                    ContactEmail = "contactEmail@asd.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish()
                        {
                            Name = "Strips",
                            Price = 10.50M
                        },
                        new Dish()
                        {
                            Name = "Fries",
                            Price = 5.50M
                        },
                        new Dish()
                        {
                            Name = "Nugets",
                            Price = 15.20M
                        }
                    },
                    Address = new Address()
                    {
                        City = "Rzeszow",
                        Street = "Wincentego Witosa 21",
                        PostalCode = "35-115"

                    }
                },
                new Restaurant()
                {
                    Name = "Pizza Hut",
                    Category = "Fast Food",
                    Description = "whaveter",
                    ContactEmail = "contactEmail@fgh.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish()
                        {
                            Name = "MEAT LOVER",
                            Price = 12.40M
                        },
                        new Dish()
                        {
                            Name = "SWEET PEPPERONI",
                            Price = 10.50M
                        },
                        new Dish()
                        {
                            Name = "PARTY DEAL",
                            Price = 15.70M
                        }
                    },
                    Address = new Address()
                    {
                        City = "Rzeszow",
                        Street = "Kopisto 1",
                        PostalCode = "35-315"

                    }
                }
            };
            return restaurants;
        }
    }
}
