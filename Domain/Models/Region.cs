using NZWalks.API.Domain.DTO;

namespace NZWalks.API.Domain.Models
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
        
        public Region(RegionDto regionDto)
        {
            Id = regionDto.Id;
            Code = regionDto.Code;
            Name = regionDto.Name;
            RegionImageUrl = regionDto.RegionImageUrl;
        }
        public Region(AddRegionDto addRegionDto)
        {
            Code = addRegionDto.Code;
            Name = addRegionDto.Name;
            RegionImageUrl = addRegionDto.RegionImageUrl;
        }

        public Region(UpdateRegionDto UpdateRegionDto)
        {
            Id = Id;
            Code = UpdateRegionDto.Code;
            Name = UpdateRegionDto.Name;
            RegionImageUrl = UpdateRegionDto.RegionImageUrl;
        }
    }
}
