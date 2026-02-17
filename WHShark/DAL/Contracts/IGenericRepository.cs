using System;
using System.Collections.Generic;

namespace DAL.Contracts
{
    public interface IGenericRepository<T>
    {
        void Add(T obj);

        void Update(T obj);

        void Delete(Guid id);

        IEnumerable<T> SelectAll();

        T SelectOne(Guid id);
    }
}
