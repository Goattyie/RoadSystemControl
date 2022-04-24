using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.BLL.Interfaces;

public interface IService<TCreateDto, TUpdateDto, TGetDto> 
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
{
    public Task<IEnumerable<TGetDto>> AddRangeAsync(params TCreateDto[] dtos);
    public Task<IEnumerable<TGetDto>> UpdateRangeAsync(params TUpdateDto[] dtos);
    public Task<IEnumerable<TGetDto>> GetAsync();
    public Task<TGetDto> GetByIdAsync(int id);
    public Task<IEnumerable<TGetDto>> RemoveRange(params int[] ids);
}