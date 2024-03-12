namespace CRUDDapperRepositoryPattern.Models
{
    internal interface IGenericRepository<T>
    {
        T? GetById(int ID);
        IEnumerable<T>? GetAll();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(int ID);
    }
}
