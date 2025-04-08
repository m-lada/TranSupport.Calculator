namespace TranSupport.Calculator.Data.Repositories.Interfaces;

public interface IRepository<IdType, TEntityDto, TCreateEntityDto, TUpdateEntityDto>
        where TEntityDto : class
        where TCreateEntityDto : class
        where TUpdateEntityDto : class
{
    Task<TEntityDto> GetAsync(IdType id);

    Task<TEntityDto> CreateAsync(TCreateEntityDto item);

    Task<TEntityDto> UpdateAsync(TUpdateEntityDto item);

    Task DeleteAsync(IdType id);
}
