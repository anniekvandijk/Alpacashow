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
    public class HaltershowEventsController : Controller
    {
        private readonly AlpacashowContext _context;

        public HaltershowEventsController(AlpacashowContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List all haltershows
        /// </summary>
        [SwaggerResponse(200, type: typeof(HaltershowEvent), description: "Ok")]
        [SwaggerResponse(0, null, description: "Unexpected error")]
        [HttpGet]
        public IEnumerable<HaltershowEvent> GetHalstershows()
        {
            return _context.HaltershowEvents
                .ToList();
        }

        /// <summary>
        /// Get a haltershow
        /// </summary>
        [SwaggerResponse(200, type: typeof(HaltershowEvent), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}", Name = "GetHaltershow")]
        public IActionResult GetHalstershow(int showEventId)
        {
            var showEvent = _context.HaltershowEvents
                .FirstOrDefault(t => t.ShowEventId == showEventId);

            if (showEvent == null)
            {
                return NotFound();
            }
            return new ObjectResult(showEvent);
        }

        /// <summary>
        /// Add a halstershow
        /// </summary>
        [SwaggerResponse(201, type: typeof(HaltershowEvent), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost]
        public IActionResult AddHalstershow([FromBody] HaltershowEvent showEvent)
        {
            if (showEvent == null)
            {
                return BadRequest();
            }

            try
            {
                _context.HaltershowEvents.Add(showEvent);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return CreatedAtRoute("GetHaltershow", new { id = showEvent.ShowEventId }, showEvent);
        }

        /// <summary>
        /// Update a halstershow
        /// </summary>
        [SwaggerResponse(200, type: typeof(HaltershowEvent), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{showEventId}", Name = "PutHalstershow")]
        public IActionResult PutHalstershow(int showEventId, [FromBody] HaltershowEvent showEvent)
        {
            if (showEvent == null || showEvent.ShowEventId != showEventId)
            {
                return BadRequest();
            }

            var showEventToUpdate = _context.HaltershowEvents
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

            try
            {
                _context.HaltershowEvents.Update(showEventToUpdate);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return CreatedAtRoute("GetHalstershow", new { id = showEvent.ShowEventId }, showEvent);
        }

        /// <summary>
        /// Delete a halstershow
        /// </summary>
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{showEventId}")]
        public IActionResult DeleteHalstershow(int showEventId)
        {
            var showEvent = _context.HaltershowEvents.FirstOrDefault(t => t.ShowEventId == showEventId);
            if (showEvent == null)
            {
                return NotFound();
            }

            _context.HaltershowEvents.Remove(showEvent);
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// Get all halstershow animals
        /// </summary>
        [SwaggerResponse(200, type: typeof(HaltershowAnimal), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}/animals", Name = "GetAnimals")]
        public IEnumerable<Animal> GetAnimals(int showEventId)
        {
            return _context.HaltershowAnimals
                .Where(x => x.HaltershowEvent.ShowEventId == showEventId)
                .ToList();
        }

        /// <summary>
        /// Get a halstershow animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(HaltershowAnimal), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}/{animalId}", Name = "GetAnimal")]
        public IActionResult GetAnimal(int showEventId, int animalId)
        {
            var showEvent = _context.HaltershowEvents.FirstOrDefault(x => x.ShowEventId == showEventId);
            var animal = _context.HaltershowAnimals.FirstOrDefault(x => x.AnimalId == animalId);
            if (showEvent == null || animal == null)
            {
                return NotFound();
            }
            return new ObjectResult(animal);
        }

        /// <summary>
        /// Add an animal to a showevent
        /// </summary>
        [SwaggerResponse(201, type: typeof(HaltershowAnimal), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost("{showEventId}/animals")]
        public IActionResult AddAnimal(int showEventId, [FromBody] HaltershowAnimal animal)
        {
            var showEvent = _context.HaltershowEvents.FirstOrDefault(t => t.ShowEventId == showEventId);
            if (showEvent == null)
            {
                return NotFound();
            }

            if (animal == null)
            {
                return BadRequest();
            }

            animal.HaltershowEvent.ShowEventId = showEventId;
            _context.HaltershowAnimals.Add(animal);

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
        /// Update a halstershow animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(HaltershowAnimal), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{showEventId}/{animalId}", Name = "PutAnimal")]
        public IActionResult PutAnimal(int showEventId, int animalId, [FromBody] HaltershowAnimal animal)
        {
            var showEvent = _context.HaltershowEvents.FirstOrDefault(x => x.ShowEventId == showEventId);
            var animalToUpdate = _context.HaltershowAnimals.FirstOrDefault(x => x.AnimalId == animalId);

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

            _context.HaltershowAnimals.Update(animalToUpdate);

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
        /// Delete a halstershowAnimal
        /// </summary>
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{showEventId}/animals/{animalId}")]
        public IActionResult DeleteAnimal(int showEventId, int animalId)
        {
            var showEvent = _context.HaltershowEvents.FirstOrDefault(x => x.ShowEventId == showEventId);
            var animal = _context.HaltershowAnimals.FirstOrDefault(x => x.AnimalId == animalId);
            if (showEvent == null || animal == null)
            {
                return NotFound();
            }
            _context.HaltershowAnimals.Remove(animal);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
