using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.BLL.Interfaces;

public interface IPositionService : IService<PositionCreateDto, PositionUpdateDto, PositionGetDto, Position>
{
    
}