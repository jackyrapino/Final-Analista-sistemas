using System;
using System.Collections.Generic;
using DomainModel;

namespace BLL.Services.Contracts
{
    public interface IBranchService
    {
        void Add(Branch branch);
        void Update(Branch branch);
        void Delete(Guid branchId);
        IEnumerable<Branch> SelectAll();
        Branch SelectOne(Guid branchId);
    }
}
