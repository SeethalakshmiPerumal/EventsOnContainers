using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _context;

        public CatalogController(CatalogContext context)
        {
            _context = context;
        }
        // GET api/catalog/items?pageSize=10&pageIndex=2

        [HttpGet]

        [Route("[action]")]

        public async Task<IActionResult> CatalogEvents(

            [FromQuery]int pageSize = 6,

            [FromQuery]int pageIndex = 0)

        {
            var eventsCount = await _context.CatalogEvents.LongCountAsync();



            var events = await _context.CatalogEvents

                 .OrderBy(c => c.EventName)

                 .Skip(pageSize * pageIndex)

                 .Take(pageSize)

                 .ToListAsync();

            return Ok(events);

        }



    }
}  


