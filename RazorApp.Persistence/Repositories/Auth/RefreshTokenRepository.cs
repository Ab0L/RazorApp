using RazorApp.Application.Contracts.Persistence.Auth;

namespace RazorApp.Persistence.Repositories.Auth
{
    public class RefreshTokenRepository : GenericRepository<Domain.Auth.RefreshToken>, IRefreshTokenRepository
    {
        private readonly RazorAppDbContext _context;
        public RefreshTokenRepository(RazorAppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
