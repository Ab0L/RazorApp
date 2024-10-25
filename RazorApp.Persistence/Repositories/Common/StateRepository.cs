using RazorApp.Application.Contracts.Persistence.Common;

namespace RazorApp.Persistence.Repositories.Common
{
    public class StateRepository : GenericRepository<Domain.Common.State>, IStateRepository
    {
        private readonly RazorAppDbContext _context;
        public StateRepository(RazorAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
