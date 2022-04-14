using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Database;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.DAL;

public class PositionRepository : Repository<Position>, IPositionRepository
{
    public PositionRepository(RscContext context) : base(context)
    {
    }
}