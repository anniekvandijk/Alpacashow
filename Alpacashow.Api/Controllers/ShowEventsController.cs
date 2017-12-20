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
