using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapperRepositoryPattern.Models
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbConnection _connection;

        public GenericRepository()
        {
            _connection = AppConnection.GetConnection();
        }

        public virtual bool Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<T>? GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual T? GetById(int ID)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
