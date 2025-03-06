using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Domain.DTO;

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

    }
}
