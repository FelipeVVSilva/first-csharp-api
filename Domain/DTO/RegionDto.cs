﻿using NZWalks.API.Domain.Models;

namespace NZWalks.API.Domain.DTO
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }

        public RegionDto(Region region) 
        {
            Id = region.Id;
            Code = region.Code;
            Name = region.Name;
            RegionImageUrl = region.RegionImageUrl;
        }
    }
}
