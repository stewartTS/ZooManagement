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
        public ActionResult<List<AnimalAPIModel>> GetAnimals([FromQuery] AnimalParameters animalParameters, [FromQuery] SearchParameters searchParameters)
        {
            var animals = _animals.GetAnimals(animalParameters, searchParameters);
            return animals.Select(a => new AnimalAPIModel(a)).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<AnimalAPIModel> GetAnimalById([FromRoute] int id)
        {
            var animal = _animals.GetAnimalById(id);

            return animal == null ? NotFound() : new AnimalAPIModel(animal);
        }

        [HttpPost("create")]
        public ActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_animals.IsEnclosureAvailable(newAnimal))
            {
                return BadRequest("Enclosure is not available.");
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
