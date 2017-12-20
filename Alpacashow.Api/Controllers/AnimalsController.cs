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
        /// Add an animal
        /// </summary>
        [SwaggerResponse(201, type: typeof(Animal), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            if (animal == null)
            {
                return BadRequest();
            }

            _context.Animals.Add(animal);

            var newAnimalOwner = new AnimalOwner
            {
                AnimalId = animal.AnimalId,
                OwnerId = animal.Owner.OwnerId,
                StartDate = DateTime.Today
            };
            _context.AnimalOwners.Add(newAnimalOwner);

            try
            {

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return CreatedAtRoute("GetAnimal", new { animalId = animal.AnimalId }, animal);
        }

        /// <summary>
        /// Update an animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{animalId}", Name = "PutAnimal")]
        public IActionResult PutAnimal(int animalId, [FromBody] Animal animal)
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
            animalToUpdate.Breed.BreedId = animal.Breed.BreedId;
            animalToUpdate.Sex.SexId = animal.Sex.SexId;
            animalToUpdate.Color.ColorId = animal.Color.ColorId;
            animalToUpdate.Chip = animal.Chip;
            animalToUpdate.Dam = animal.Dam;
            animalToUpdate.Sire = animal.Sire;
            animalToUpdate.Dob = animal.Dob;

            _context.Animals.Update(animalToUpdate);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return CreatedAtRoute("GetAnimal", animal);
        }

        /// <summary>
        /// Update an animal owner
        /// </summary>
        [SwaggerResponse(200, type: typeof(AnimalOwner), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{animalId}/{oldOwnerId}/{newOwnerId}", Name = "PutAnimalOwner")]
        public IActionResult PutAnimalOwner(int animalId, int oldOwnerId, int newOwnerId)
        { 
            var animalToUpdate = _context.Animals
                .FirstOrDefault(x => x.AnimalId == animalId);

            var oldAnimalOwner = _context.AnimalOwners
                .FirstOrDefault(x => x.AnimalId == animalId && x.OwnerId == oldOwnerId);
            var owner = _context.Owners
                .FirstOrDefault(x => x.OwnerId == newOwnerId);
            if (animalToUpdate == null)
            {
                return NotFound("Animal not found");
            }
            if (oldAnimalOwner == null)
            {
                return NotFound("Old animal owner not found");
            }
            if (owner == null)
            {
                return NotFound("New owner owner not found");
            }

            // set enddate old owner
            var endDate = DateTime.Now.Subtract(TimeSpan.FromDays(1));
            oldAnimalOwner.EndDate = endDate;
                _context.AnimalOwners.Update(oldAnimalOwner);

            // set new owner
            var newAnimalOwner = new AnimalOwner
            {
                AnimalId = animalId,
                OwnerId =owner.OwnerId,
                StartDate = DateTime.Now
            };
            _context.AnimalOwners.Add(newAnimalOwner);

            animalToUpdate.Owner.OwnerId = newOwnerId;

            _context.SaveChanges();

            return CreatedAtRoute("GetAnimal", animalToUpdate);
        }
       
        /// <summary>
        /// Delete a animal
        /// </summary>
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{animalId}")]
        public IActionResult DeleteAnimal(int animalId)
        {
            var animal = _context.Animals.FirstOrDefault(t => t.AnimalId == animalId);
            if (animal == null)
            {
                return NotFound();
            }

            var animalOwners = _context.AnimalOwners
                .Where(x => x.AnimalId == animalId);

            foreach (var animalOwner in animalOwners)
            {
                _context.AnimalOwners.Remove(animalOwner);
            }

            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
