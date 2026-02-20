using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Services.Contracts;
using DAL.Contracts;
using DAL.Implementations;
using DomainModel;

namespace BLL.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _repo;

        public BranchService(IBranchRepository repo)
        {
            _repo = repo;
        }

        
        public BranchService() : this(BranchRepository.Current) { }

        public void Add(Branch branch)
        {
            try
            {
                if (branch == null) throw new ArgumentNullException(nameof(branch));
                if (branch.BranchId == Guid.Empty) branch.BranchId = Guid.NewGuid();
                branch.CreatedAt = DateTime.Now;
                _repo.Add(branch);
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding branch.", ex);
            }
        }

        public void Update(Branch branch)
        {
            try
            {
                if (branch == null) throw new ArgumentNullException(nameof(branch));
                _repo.Update(branch);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating branch.", ex);
            }
        }

        public void Delete(Guid branchId)
        {
            try
            {
                _repo.Delete(branchId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting branch.", ex);
            }
        }

        public IEnumerable<Branch> SelectAll()
        {
            try
            {
                return _repo.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving branches.", ex);
            }
        }

        public Branch SelectOne(Guid branchId)
        {
            try
            {
                return _repo.SelectOne(branchId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving branch.", ex);
            }
        }
    }
}
