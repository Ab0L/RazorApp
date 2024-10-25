using RazorApp.Application.Contracts.Persistence.Common;

namespace RazorApp.Persistence.Repositories.Common
{
    public class CityRepository : GenericRepository<Domain.Common.City>, ICityRepository
    {
        private readonly RazorAppDbContext _context;
        public CityRepository(RazorAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
