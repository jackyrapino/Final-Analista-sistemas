using System;
using System.Collections.Generic;
using DomainModel;

namespace DAL.Contracts
{
    public interface IBrandRepository : IGenericRepository<Brand>
    {
        Brand GetByName(string name);
        IEnumerable<Brand> SearchByName(string term);
    }
}
