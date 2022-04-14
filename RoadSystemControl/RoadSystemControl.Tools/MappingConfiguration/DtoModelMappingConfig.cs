using AutoMapper;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.Tools.MappingConfiguration;

public class DtoModelMappingConfig : Profile
{
    public DtoModelMappingConfig()
    {
        CreateMap<LocationCreateDto, Location>();
        CreateMap<LocationGetDto, Location>().ReverseMap();
        CreateMap<LocationUpdateDto, Location>();
    }
}