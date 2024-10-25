using RazorApp.Application.Contracts.Persistence.Auth;

namespace RazorApp.Persistence.Repositories.Auth
{
    public class LoginHelperSessionRepository : GenericRepository<Domain.Auth.LoginHelperSession>, ILoginHelperSessionRepository
    {
        private readonly RazorAppDbContext _context;
        public LoginHelperSessionRepository(RazorAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
