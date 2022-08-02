using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly EmployeeContext _context;

        public GenericRepository(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            var query = ApplySpecification(spec);
            return await query.FirstAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            var query = ApplySpecification(spec);
            return await query.ToListAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}