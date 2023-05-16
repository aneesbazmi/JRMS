namespace JRMS.AbstractionLayer
{
    public interface IGenericRepository<T>  where T : class
    {
        T GetByID(int? id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T Entity);
        void Delete(int Id);

        bool IsNull();
    }
}
