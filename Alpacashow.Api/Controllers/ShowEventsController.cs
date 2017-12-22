using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ShowEventsController : Controller
    {
        private readonly AlpacashowContext _context;

        public ShowEventsController(AlpacashowContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List all showevents
        /// </summary>
        [SwaggerResponse(200, type: typeof(ShowEvent), description: "Ok")]
        [SwaggerResponse(0, null, description: "Unexpected error")]
        [HttpGet]
        public IEnumerable<ShowEvent> GetShowEvents()
        {
            return _context.ShowEvents
                .ToList();
        }

        /// <summary>
        /// Get a showevent
        /// </summary>
        [SwaggerResponse(200, type: typeof(ShowEvent), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}", Name = "GetShowEvent")]
        public IActionResult GetShowEvent(int showEventId)
        {
            var showEvent = _context.ShowEvents
                .FirstOrDefault(t => t.ShowEventId == showEventId);

            if (showEvent == null)
            {
                return NotFound();
            }
            return new ObjectResult(showEvent);
        }

        /// <summary>
        /// Add a showevent
        /// </summary>
        [SwaggerResponse(201, type: typeof(ShowEvent), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost]
        public IActionResult Create([FromBody] ShowEvent showEvent)
        {
            if (showEvent == null)
            {
                return BadRequest();
            }

            try
            {
                _context.ShowEvents.Add(showEvent);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return CreatedAtRoute("GetShowEvent", new { id = showEvent.ShowEventId }, showEvent);
        }

        /// <summary>
        /// Update a showevent
        /// </summary>
        [SwaggerResponse(200, type: typeof(ShowEvent), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{showEventId}", Name = "PutShowEvent")]
        public IActionResult Put(int showEventId, [FromBody] ShowEvent showEvent)
        {
            if (showEvent == null || showEvent.ShowEventId != showEventId)
            {
                return BadRequest();
            }

            var showEventToUpdate = _context.ShowEvents
                .Include(s => s.ShowType.ShowTypeId)
                .FirstOrDefault(t => t.ShowEventId == showEventId);
            if (showEventToUpdate == null)
            {
                return NotFound();
            }

            showEventToUpdate.Name = showEvent.Name;
            showEventToUpdate.Location = showEvent.Location;
            showEventToUpdate.Date = showEvent.Date;
            showEventToUpdate.Judge = showEvent.Judge;
            showEventToUpdate.Archived = showEvent.Archived;
            showEventToUpdate.ShowType.ShowTypeId = showEvent.ShowType.ShowTypeId;

            try
            {
                _context.ShowEvents.Update(showEventToUpdate);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return CreatedAtRoute("GetShowEvent", new { id = showEvent.ShowEventId }, showEvent);
        }

        /// <summary>
        /// Delete a showevent
        /// </summary>
        [SwaggerOperation("DeleteShowEvent")]
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{showEventId}")]
        public IActionResult Delete(int showEventId)
        {
            var showEvent = _context.ShowEvents.FirstOrDefault(t => t.ShowEventId == showEventId);
            if (showEvent == null)
            {
                return NotFound();
            }

            _context.ShowEvents.Remove(showEvent);
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// Get all showevent animals
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}/animals", Name = "GetShowEventAnimals")]
        public IEnumerable<Animal> GetShowEventAnimals(int showEventId)
        {
            return _context.Animals
                .Where(x => x.ShowEvent.ShowEventId == showEventId)
                .ToList();
        }

        /// <summary>
        /// Get a showevent animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}/{animalId}", Name = "GetAnimal")]
        public IActionResult GetAnimal(int showEventId, int animalId)
        {
            var showEvent = _context.ShowEvents.FirstOrDefault(x => x.ShowEventId == showEventId);
            var animal = _context.Animals.FirstOrDefault(x => x.AnimalId == animalId);
            if (showEvent == null || animal == null)
            {
                return NotFound();
            }
            return new ObjectResult(animal);
        }

        /// <summary>
        /// Add an animal to a showevent
        /// </summary>
        [SwaggerResponse(201, type: typeof(Animal), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost("{showEventId}/animals")]
        public IActionResult AddShowEventAnimal(int showEventId, [FromBody] Animal animal)
        {
            var showEvent = _context.ShowEvents.FirstOrDefault(t => t.ShowEventId == showEventId);
            if (showEvent == null)
            {
                return NotFound();
            }

            if (animal == null)
            {
                return BadRequest();
            }

            animal.ShowEvent.ShowEventId = showEventId;
            _context.Animals.Add(animal);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return new ObjectResult(animal);
        }

        /// <summary>
        /// Update a showevent animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{showEventId}/{animalId}", Name = "PutAnimal")]
        public IActionResult PutAnimal(int showEventId, int animalId, [FromBody] Animal animal)
        {
            var showEvent = _context.ShowEvents.FirstOrDefault(x => x.ShowEventId == showEventId);
            var animalToUpdate = _context.Animals.FirstOrDefault(x => x.AnimalId == animalId);

            if (showEvent == null || animalToUpdate == null)
            {
                return NotFound();
            }
            if (animal == null)
            {
                return BadRequest();
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
        /// Delete an animal from a showevent
        /// </summary>
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{showEventId}/animals/{animalId}")]
        public IActionResult DeleteShowEventAnimal(int showEventId, int animalId)
        {
            var showEvent = _context.ShowEvents.FirstOrDefault(x => x.ShowEventId == showEventId);
            var animal = _context.Animals.FirstOrDefault(x => x.AnimalId == animalId);
            if (showEvent == null || animal == null)
            {
                return NotFound();
            }
            _context.Animals.Remove(animal);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
