using RazorApp.Application.Contracts.Persistence;

namespace RazorApp.Persistence.Repositories
{
    public class AddressRepository : GenericRepository<Domain.Address>, IAddressRepository
    {
        private readonly RazorAppDbContext _context;
        public AddressRepository(RazorAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
