using RestaurantAPI.Models;
using System.Collections.Generic;

namespace RestaurantAPI.Interface
{
    public interface IRestaurantService
    {
        int CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        void Delete(int id);
        void Update(int id, UpdateRestaurantDto dto);
    }
}