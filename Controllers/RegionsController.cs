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
        public IActionResult CreateRegion([FromBody] AddRegionDto addRegionDto)
        {
            var region = new Region(addRegionDto);

            _dbContext.Regions.Add(region);
            _dbContext.SaveChanges();

            return Ok(new RegionDto(region));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionDto updateRegionDto)
        {
            var region = _dbContext.Regions.First(x => x.Id == id);
            
            if (region != null)
            {
                updateRegion(region, updateRegionDto);
                _dbContext.Regions.Update(region);
                _dbContext.SaveChanges();

                return Ok(new RegionDto(region));
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {

            var region = _dbContext.Regions.First(x => x.Id == id);

            if (region != null)
            {
                _dbContext.Regions.Remove(region);
                _dbContext.SaveChanges();
                return Ok(new RegionDto(region));
            }

            return NotFound();
        }

        private void updateRegion(Region region, UpdateRegionDto updateRegionDto)
        {
            region.Code = updateRegionDto.Code;
            region.Name = updateRegionDto.Name;
            region.RegionImageUrl = updateRegionDto.RegionImageUrl;
        }
    }
}
