using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext restaurantDbContext;
        public RestaurantController(RestaurantDbContext restaurantDbContext)
        {
            restaurantDbContext = this.restaurantDbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Restaurant>> GetAll()
        {
            var result = restaurantDbContext
                .Restaurants
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Restaurant>> Get([FromRoute] int id)
        {
            var result = restaurantDbContext
                .Restaurants
                .FirstOrDefault(r => r.Id == id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
