using BLL.Services.Contracts;
using DAL.Contracts;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void Add(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            category.CategoryId = Guid.NewGuid();
            _categoryRepository.Add(category);
        }
    }
}
