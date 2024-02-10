using DbAssignment.Contexts;
using System.Diagnostics;
using System.Linq.Expressions;


namespace DbAssignment.Repositories;

internal class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    public Repo(DataContext context)
    {
        _context = context;
    }

    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;  
    }

    public virtual TEntity GetOne(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var result = _context.Set<TEntity>().FirstOrDefault(expression);
            if (result != null) 
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            var result = _context.Set<TEntity>().ToList();
            if (result != null)
            {
                return result;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual TEntity Update(TEntity entity)
    {
        try
        {
            var entityUpdate = _context.Set<TEntity>().Find(entity);
            if (entityUpdate != null)
            {
                entityUpdate = entity;
                _context.Set<TEntity>().Update(entityUpdate);
                _context.SaveChanges();

                return entityUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public virtual bool Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();

                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
