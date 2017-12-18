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
    public class ShowEventsAnimalsController : Controller
    {
        private readonly AlpacashowContext _context;

        public ShowEventsAnimalsController(AlpacashowContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Add an animal to a showevent
        /// </summary>
        [SwaggerResponse(201, type: typeof(ShowEventAnimal), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost("{showEventId}/{animalId}")]
        public IActionResult AddShowEventAnimal(int showEventId, int animalId)
        {
            if (showEventId == 0 || animalId == 0)
            {
                return BadRequest();
            }

            var showEventAnimal = new ShowEventAnimal
            {
                ShowEventId = showEventId,
                AnimalId = animalId
            };

            try
            {
                _context.ShowEventAnimals.Add(showEventAnimal);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return CreatedAtRoute("GetShowEventAnimal", new { showEventId = showEventAnimal.ShowEventId, animalId = showEventAnimal.AnimalId }, showEventAnimal);
        }

        /// <summary>
        /// Delete an animal from a showevent
        /// </summary>
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{showEventId}/{animalId}")]
        public IActionResult DeleteShowEventAnimal(int showEventId, int animalId)
        {
            var showEventAnimal = _context.ShowEventAnimals.FirstOrDefault(t => t.AnimalId == animalId && t.ShowEventId == showEventId);
            if (showEventAnimal == null)
            {
                return NotFound();
            }

            _context.ShowEventAnimals.Remove(showEventAnimal);
            _context.SaveChanges();
            return new NoContentResult();
        }

        /// <summary>
        /// Get a showevent animal
        /// </summary>
        [SwaggerResponse(200, type: typeof(ShowEvent), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}/{AnimalId}", Name = "GetShowEventAnimal")]
        public IActionResult GetShowEventAnimal(int showEventId, int animalId)
        {
            var showEventAnimal = _context.ShowEventAnimals
                .FirstOrDefault(t => t.ShowEventId == showEventId && t.AnimalId == animalId);

            if (showEventAnimal == null)
            {
                return NotFound();
            }
            return new ObjectResult(showEventAnimal);
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
                .Where(x => x.ShowEventAnimal.Any(y => y.ShowEventId == showEventId))
                .ToList();
        }

        /// <summary>
        /// Get all showevent participants
        /// </summary>
        [SwaggerResponse(200, type: typeof(Owner), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{showEventId}/participants", Name = "GetShowEventParticipants")]
        public IEnumerable<Owner> GetShowEventParticipants(int showEventId)
        {
            return _context.Owners
                .Where(x => x.Animals.Any(y => y.ShowEventAnimal.Any(z => z.ShowEventId == showEventId)))
                .ToList();
        }
    }
}
