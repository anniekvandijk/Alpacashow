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
    public class OwnersController : Controller
    {
        private readonly AlpacashowContext _context;

        public OwnersController(AlpacashowContext context)
        {
            _context = context;
        }

        /// <summary>
        /// List all owners
        /// </summary>
        [SwaggerResponse(200, type: typeof(Owner), description: "Ok")]
        [SwaggerResponse(0, null, description: "Unexpected error")]
        [HttpGet]
        public IEnumerable<Owner> GetOwners()
        {
            return _context.Owners
                .ToList();
        }

        /// <summary>
        /// Get a owner
        /// </summary>
        [SwaggerResponse(200, type: typeof(Owner), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{ownerId}", Name = "GetOwner")]
        public IActionResult GetOwner(int ownerId)
        {
            var owner = _context.Owners
                .FirstOrDefault(t => t.OwnerId == ownerId);

            if (owner == null)
            {
                return NotFound();
            }
            return new ObjectResult(owner);
        }

        /// <summary>
        /// Get a owner animals
        /// </summary>
        [SwaggerResponse(200, type: typeof(Animal), description: "Ok")]
        [SwaggerResponse(404, null, description: "Not found")]
        [HttpGet("{ownerId}/animals", Name = "GetOwnerAnimals")]
        public IEnumerable<Animal> GetOwnerAnimals(int ownerId)
        {
            return _context.Animals
                .Where(x => x.Owner.OwnerId == ownerId)
                .ToList();
        }

        /// <summary>
        /// Post a owner
        /// </summary>
        [SwaggerResponse(201, type: typeof(Owner), description: "Created")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPost]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            if (owner == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Owners.Add(owner);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            return CreatedAtRoute("GetOwner", new { ownerId = owner.OwnerId }, owner);
        }

        /// <summary>
        /// Update a owner
        /// </summary>
        [SwaggerResponse(200, type: typeof(Owner), description: "Updated")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpPut("{ownerId}", Name = "PutOwner")]
        public IActionResult PutOwner(int ownerId, [FromBody] Owner owner)
        {
            if (owner == null || owner.OwnerId != ownerId)
            {
                return BadRequest();
            }

            var ownerToUpdate = _context.Owners
                .FirstOrDefault(t => t.OwnerId == ownerId);
            if (ownerToUpdate == null)
            {
                return NotFound();
            }

            ownerToUpdate.Name = owner.Name;
            ownerToUpdate.FarmName = owner.FarmName;

            try
            {
                _context.Owners.Update(ownerToUpdate);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            return CreatedAtRoute("GetOwner", owner);
        }

        /// <summary>
        /// Delete a owner
        /// </summary>
        [SwaggerResponse(204, null, description: "No content")]
        [SwaggerResponse(404, null, description: "Not found")]
        [SwaggerResponse(400, null, description: "Bad request")]
        [HttpDelete("{ownerId}")]
        public IActionResult DeleteOwner(int ownerId)
        {
            var owner = _context.Owners.FirstOrDefault(t => t.OwnerId == ownerId);
            if (owner == null)
            {
                return NotFound();
            }

            _context.Owners.Remove(owner);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
