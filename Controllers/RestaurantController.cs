using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Interface;
using RestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurantDtos = _restaurantService.GetAll();
            
            return Ok(restaurantDtos);
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RestaurantDto>> Get([FromRoute] int id)
        {
            var result = _restaurantService.GetById(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantDto dto)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */
            var id = _restaurantService.CreateRestaurant(dto);
            return Created($"/api/restaurant/{id}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);
            return NoContent();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateRestaurantDto updateRestaurantDto)
        {
             _restaurantService.Update(id,updateRestaurantDto);

            return Ok();
        }
    }
}
