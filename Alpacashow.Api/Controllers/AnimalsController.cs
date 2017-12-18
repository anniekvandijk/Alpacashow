using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpacashow.Data.Context;
using Alpacashow.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Alpacashow.Api.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AnimalsController : Controller
    {
        private readonly AlpacashowContext _context;

        public AnimalsController(AlpacashowContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List all animals
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Ok")]
        [SwaggerResponse(0, null, description: "Unexpected error")]
        [HttpGet]
        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals
                .ToList();
        }

        /// <summary>
        /// Get a animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{animalId}", Name = "GetAnimal")]
        public IActionResult GetAnimal(int animalId)
        {
            var animal = _context.Animals
                .FirstOrDefault(t => t.AnimalId == animalId);

            if (animal == null)
            {
                return NotFound();
            }
            return new ObjectResult(animal);
        }

        /// <summary>
        /// Post a animal
        /// </summary>
        [SwaggerResponse(201, type: typeof(Animal), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost]
        public IActionResult Create([FromBody] Animal animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Animals.Add(animal);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return CreatedAtRoute("GetAnimal", new { animalId = animal.AnimalId }, animal);
        }

        /// <summary>
        /// Update a animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{animalId}", Name = "PutAnimal")]
        public IActionResult Put(int animalId, [FromBody] Animal animal)
        {
            if (animal == null || animal.AnimalId != animalId)
            {
                return BadRequest();
            }

            var animalToUpdate = _context.Animals
                .FirstOrDefault(t => t.AnimalId == animalId);
            if (animalToUpdate == null)
            {
                return NotFound();
            }

            animalToUpdate.Name = animal.Name;
            animalToUpdate.BreedId = animal.BreedId;
            animalToUpdate.SexId = animal.SexId;
            animalToUpdate.ColorId = animal.ColorId;
            animalToUpdate.OwnerId = animal.OwnerId;
            animalToUpdate.Chip = animal.Chip;
            animalToUpdate.Dam = animal.Dam;
            animalToUpdate.Sire = animal.Sire;
            animalToUpdate.Dob = animal.Dob;

            try
            {
                _context.Animals.Update(animalToUpdate);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return CreatedAtRoute("GetAnimal", animal);
        }

        /// <summary>
        /// Delete a animal
        /// </summary>
        [SwaggerOperation("DeleteAnimal")]
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{animalId}")]
        public IActionResult Delete(int animalId)
        {
            var animal = _context.Animals.FirstOrDefault(t => t.AnimalId == animalId);
            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
