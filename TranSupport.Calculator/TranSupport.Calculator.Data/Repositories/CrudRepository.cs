using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TranSupport.Calculator.Shared.Interfaces.Database;
using TranSupport.Calculator.Shared.Interfaces.Repositories;

namespace TranSupport.Calculator.Data.Repositories;

public class CrudRepository<TEntity, TDomain, IdType> : IRepository<IdType, TDomain>
        where TEntity : class, IAuditedDbEntity<IdType>
        where TDomain : class
{
    protected readonly IMapper _mapper;
    protected DatabaseContext _context { get; }
    protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

    public CrudRepository(DatabaseContext dbContext, IMapper mapper)
    {
        _context = dbContext;
        _mapper = mapper;
    }

    public async Task<TDomain> AddAsync(TDomain item)
    {
        var entity = _mapper.Map<TEntity>(item);

        entity.CreatedAt = DateTime.Now;
        //TODO
        //Add concurrency stamp and creator/modifier Id from logged user

        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();

        return _mapper.Map<TDomain>(entity);
    }

    public async Task<TDomain> GetByIdAsync(IdType id)
    {
        var entity = await DbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        return _mapper.Map<TDomain>(entity);
    }

    public async Task<IList<TDomain>> GetAllAsync()
    {
        var listOfEntities = await DbSet.AsNoTracking().ToListAsync();

        return listOfEntities
            .Select(x => _mapper.Map<TDomain>(x))
            .ToList();
    }

    public async Task<TDomain> UpdateAsync(TDomain item)
    {
        var entity = _mapper.Map<TEntity>(item);
        var mappedEntity = await DbSet.FindAsync(entity.Id);

        if (mappedEntity == null)
        {
            throw new ArgumentException($"Entity with given id `{entity.Id}` not found!");
        }

        entity.ModifiedAt = DateTime.UtcNow;
        entity.CreatedAt = mappedEntity.CreatedAt;
        //TODO
        //Add concurrency stamp and creator/modifier Id from logged user

        _context.Entry(mappedEntity).Property(x => x.CreatedAt).IsModified = false;
        _context.Entry(mappedEntity).CurrentValues.SetValues(entity);

        await _context.SaveChangesAsync();

        return _mapper.Map<TDomain>(mappedEntity);
    }

    public async Task DeleteAsync(IdType id)
    {
        var mappedEntity = DbSet.Find(id);

        if (mappedEntity == null)
        {
            throw new ArgumentException($"Entity with given id `{id}` not found!");
        }

        DbSet.Attach(mappedEntity);
        DbSet.Remove(mappedEntity);

        await _context.SaveChangesAsync();
    }
}
