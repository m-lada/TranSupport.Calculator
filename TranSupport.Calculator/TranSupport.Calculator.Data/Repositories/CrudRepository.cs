using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TranSupport.Calculator.Data.Repositories.Interfaces;
using TranSupport.Calculator.Data.Repositories.Interfaces.Database;

namespace TranSupport.Calculator.Data.Repositories;

public class CrudRepository<TEntity, TDomain, IdType> : IRepository<IdType, TDomain>
        where TEntity : class, IAuditedDbEntity<IdType>
        where TDomain : class
{
    protected readonly IMapper _mapper;
    protected readonly ICurrentUserService _currentUserService;

    protected DatabaseContext _context { get; }
    protected DbSet<TEntity> DbSet => _context.Set<TEntity>();

    public CrudRepository(DatabaseContext dbContext, IMapper mapper, ICurrentUserService currentUserService)
    {
        _context = dbContext;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<TDomain> AddAsync(TDomain item)
    {
        var entity = _mapper.Map<TEntity>(item);

        entity.CreatorId = _currentUserService.UserId;
        entity.CreatedAt = DateTime.Now;

        entity.ConcurrencyStamp = Guid.NewGuid().ToString();

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
        var updatedEntity = _mapper.Map<TEntity>(item);
        var dbEntity = await DbSet.FindAsync(updatedEntity.Id);

        if (dbEntity == null)
        {
            throw new ArgumentException($"Entity with given id `{updatedEntity.Id}` not found!");
        }

        if (dbEntity.ConcurrencyStamp != updatedEntity.ConcurrencyStamp)
        {
            throw new DbUpdateConcurrencyException("Record was modified by another user.");
        }

        updatedEntity.ConcurrencyStamp = Guid.NewGuid().ToString();

        updatedEntity.ModifiedAt = DateTime.UtcNow;
        updatedEntity.CreatedAt = dbEntity.CreatedAt;
        updatedEntity.ModifierId = _currentUserService.UserId;

        _context.Entry(dbEntity).Property(x => x.CreatedAt).IsModified = false;
        _context.Entry(dbEntity).CurrentValues.SetValues(updatedEntity);

        await _context.SaveChangesAsync();

        return _mapper.Map<TDomain>(dbEntity);
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
