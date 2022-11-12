using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Querys;
using Domain.ValueObjects;
using Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Repositories.Entities.Bases
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DatabasePostgresContext _context;

        protected BaseRepository(DatabasePostgresContext context)
        {
            _context = context;
        }

        public virtual Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().FirstOrDefaultAsync(predicate, cancellationToken);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao encontrar entidade", e);
            }
        }

        public virtual Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().AnyAsync(predicate, cancellationToken);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao encontrar entidade", e);
            }
        }

        public virtual Task<List<TEntity>> ManyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao encontrar entidades", e);
            }
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().CountAsync(predicate, cancellationToken);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao contar entidades", e);
            }
        }

        public virtual Task<bool> AllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().AllAsync(predicate, cancellationToken);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao verificar entidades", e);
            }
        }

        public virtual Task<List<TEntity>> ToListAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao listar entidades", e);
            }
        }

        public virtual async Task<int> MaxAsync(Expression<Func<TEntity, int>> predicate, CancellationToken cancellationToken = default)
        {
            try
            {
                var exists = await _context.Set<TEntity>().AnyAsync(cancellationToken);
                if (exists)
                    return await _context.Set<TEntity>().MaxAsync(predicate, cancellationToken);
                return 1;
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao lbuscar maior valor", e);
            }
        }

        public virtual IQueryable<TEntity> AsQueryable() =>
            _context.Set<TEntity>().AsQueryable();

        public virtual Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().AddAsync(entity, cancellationToken).AsTask();
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao adicionar entidade", e);
            }
        }

        public virtual Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                return _context.Set<TEntity>().AddRangeAsync(entities, cancellationToken);
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao adicionar multiplas entidades", e);
            }
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity), "Não pode ser nulo");

                cancellationToken.ThrowIfCancellationRequested();
                if (_context.Entry(entity).State == EntityState.Detached)
                    _context.Set<TEntity>().Attach(entity);
                _context.Set<TEntity>().Update(entity);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao atualizar entidade", e);
            }
        }

        public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities), "Não pode ser nulo");

                cancellationToken.ThrowIfCancellationRequested();
                var entitiesDetached = entities.Where(ent => _context.Entry(ent).State == EntityState.Deleted);
                if (entitiesDetached.Any())
                    _context.Set<TEntity>().AttachRange(entitiesDetached);
                _context.Set<TEntity>().UpdateRange(entities);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao atualizar entidade", e);
            }
        }

        public virtual Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                _context.Set<TEntity>().Remove(entity);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao atualizar entidade", e);
            }
        }

        public virtual Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                _context.Set<TEntity>().RemoveRange(entities);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new RepositoryException("Erro ao atualizar entidade", e);
            }
        }

        public Task<Paginated<TEntity>> ManyAsyncPaginated(Expression<Func<TEntity, bool>> predicate, PaginetedOrderQuery queryParams)
        {
            throw new NotImplementedException();
        }
    }
}