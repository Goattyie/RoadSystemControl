using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Database;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.DAL;

public class LocationRepository: Repository<Location>, ILocationRepository
{
    public LocationRepository(RscContext context) : base(context) { }
}