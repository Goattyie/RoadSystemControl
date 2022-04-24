using AutoMapper;
using RoadSystemControl.BLL.Interfaces;
using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Domains.Dtos.Create;
using RoadSystemControl.Domains.Dtos.Get;
using RoadSystemControl.Domains.Dtos.Update;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.BLL;

public abstract class AbstractService <TCreateDto, TUpdateDto, TGetDto, TModel> : IService<TCreateDto, TUpdateDto, TGetDto>
    where TCreateDto : ICreateDto
    where TUpdateDto : IUpdateDto
    where TGetDto : IGetDto
    where TModel : BaseModel
{
    protected IMapper Mapper { get; }
    protected IRepository<TModel> Repository { get; }

    protected AbstractService(IMapper mapper, IRepository<TModel> repository)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public virtual async Task<IEnumerable<TGetDto>> AddRangeAsync(params TCreateDto[] dtos)
    {
        var entities = Mapper.Map<TModel[]>(dtos);
        
        await Repository.CreateRangeAsync(entities);

        return Mapper.Map<IEnumerable<TGetDto>>(entities);
    }

    public virtual async Task<IEnumerable<TGetDto>> UpdateRangeAsync(params TUpdateDto[] dtos)
    {
        var entities = Mapper.Map<TModel[]>(dtos);
        
        await Repository.UpdateRangeAsync(entities);

        return Mapper.Map<IEnumerable<TGetDto>>(entities);
    }

    public virtual async Task<IEnumerable<TGetDto>> GetAsync()
    {
        var entities = await Repository.GetAsync();

        return Mapper.Map<IEnumerable<TGetDto>>(entities);
    }

    public virtual async Task<TGetDto> GetByIdAsync(int id)
    {
        var entity = await Repository.FindByIdAsync(id);

        return Mapper.Map<TGetDto>(entity);
    }

    public async Task<IEnumerable<TGetDto>> RemoveRange(params int[] ids)
    {
        var getEntitiesByIdQuery = Repository.GetQuery().Where(x => ids.Contains(x.Id));
        var removedEntities = getEntitiesByIdQuery.ToArray();
        
        await Repository.RemoveRangeAsync(removedEntities);

        return Mapper.Map<IEnumerable<TGetDto>>(removedEntities);
    }
}