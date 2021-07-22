using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZooManagement.Models;
using ZooManagement.Models.API;
using ZooManagement.Models.Database;
using ZooManagement.Repositories;
using ZooManagement.Request;

namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("/animals")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animals)
        {
            _animals = animals;
        }

        [HttpGet("search")]
        public ActionResult<AnimalAPIModel> GetAnimals([FromQuery] AnimalParameters animalParameters)
        {
            var animals = _animals.GetAnimals(animalParameters);
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalAPIModel> GetAnimalById([FromRoute] int id)
        {
            var animal = _animals.GetAnimalById(id);
            return new AnimalAPIModel(animal);
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _animals.Create(newAnimal);

            return Ok();
        }

        [HttpGet("species")]
        public ActionResult<List<string>> GetAllSpecies()
        {
            return _animals.GetAllSpecies();
            
        }

    }
}
