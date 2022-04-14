using AutoMapper;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.BLL;

public class PositionService : AbstractService<PositionCreateDto, PositionUpdateDto, PositionGetDto, Position>, IPositionService
{
    public PositionService(IMapper mapper, IPositionRepository repository) : base(mapper, repository)
    {
    }
}