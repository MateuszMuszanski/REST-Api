using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Entities;
using RestaurantAPI.Excepions;
using RestaurantAPI.Interface;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContex;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;
        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantService> logger)
        {
            _dbContex = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public RestaurantDto GetById(int id)
        {
            var restaurant = _dbContex.Restaurants
                .Include(a => a.Address)
                .Include(a => a.Dishes)
                .FirstOrDefault(a => a.Id == id);

            if (restaurant is null)
            {
                throw new NotFoundExcepion("Not Found");
            }

            var result = _mapper.Map<RestaurantDto>(restaurant);

            return result;
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var restaurants = _dbContex.Restaurants
                .Include(a => a.Address)
                .Include(a => a.Dishes)
                .ToList();
            if (restaurants is null)
            {
                return null;
            }

            var results = _mapper.Map<List<RestaurantDto>>(restaurants);

            return results;
        }

        public int CreateRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(createRestaurantDto);
            _dbContex.Restaurants.Add(restaurant);
            _dbContex.SaveChanges();
            return restaurant.Id;
        }
        public void Delete(int id)
        {
            _logger.LogWarning($"Restaurant with id: {id} DELETE action invoked");

            var restaurant = _dbContex.Restaurants
                .FirstOrDefault(r => r.Id == id);

            if (restaurant is null)
            {
                throw new NotFoundExcepion("");
            }

            _dbContex.Restaurants.Remove(restaurant);
            _dbContex.SaveChanges();
        }
        public void Update(int id, UpdateRestaurantDto updateRestaurantDto)
        {
            var result = _dbContex.Restaurants
                .FirstOrDefault(r => r.Id == id);

            if (result is null)
            {
                throw new NotFoundExcepion("Not Found");
            }

            result.Name = updateRestaurantDto.Name;
            result.HasDelivery = updateRestaurantDto.HasDelivery;
            result.Description = updateRestaurantDto.Description;

            _dbContex.SaveChanges();
        }
    }
}
