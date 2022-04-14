using AutoMapper;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.BLL;

public class LocationService : AbstractService<LocationCreateDto, LocationUpdateDto, LocationGetDto, Location>, ILocationService
{
    public LocationService(IMapper mapper, ILocationRepository repository) : base(mapper, repository)
    {
    }
}