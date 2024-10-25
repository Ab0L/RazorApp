using RazorApp.Application.Contracts.Persistence.Common;

namespace RazorApp.Persistence.Repositories.Common
{
    public class CountryRepository : GenericRepository<Domain.Common.Country>, ICountryRepository
    {
        private readonly RazorAppDbContext _context;
        public CountryRepository(RazorAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
