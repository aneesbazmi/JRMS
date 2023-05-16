using JRMS.DAL;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace JRMS.AbstractionLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly JMSDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(JMSDbContext dbContext) 
        {
            _context = dbContext;
            _dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(int Id)
        {
            var recordToBeDeleted = _dbSet.Find(Id);
            if (recordToBeDeleted != null)
            {
                _dbSet.Remove(recordToBeDeleted);
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetByID(int? Id)
        {
            if (Id == null)
                return null;
            return _dbSet.Find(Id);
        }

        public bool IsNull()
        {
            if (_dbSet == null)
            {
                return true;
            }
            else
                return false;
        }

        public void Update(T Entity)
        {
            _dbSet.Update(Entity);
        }
    }
}
