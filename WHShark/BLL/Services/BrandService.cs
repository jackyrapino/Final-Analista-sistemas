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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public void Add(Brand brand)
        {
            if (brand == null) throw new ArgumentNullException(nameof(brand));
            brand.BrandId = Guid.NewGuid();
            _brandRepository.Add(brand);
        }
    }
}
