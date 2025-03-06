using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Domain.DTO;
using NZWalks.API.Domain.Models;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly NZWalksDbContext _dbContext;

        public RegionsController(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = _dbContext.Regions.ToList();

            var regionDto = new List<RegionDto>();

            foreach(var region in regions)
            {
                regionDto.Add(new RegionDto(region));
            }

            return Ok(regionDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = _dbContext.Regions.First(x => x.Id == id);

            if (region != null)
            {
                var regionDto = new RegionDto(region);

                return Ok(regionDto);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateRegion([FromBody] RegionDto regionDto)
        {
            var region = new Region(regionDto);

            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

            return Ok(region);
        }
    }
}
