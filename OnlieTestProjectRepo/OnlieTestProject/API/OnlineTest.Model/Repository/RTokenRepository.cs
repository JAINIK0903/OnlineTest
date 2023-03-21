using OnlineTest.Models.Interfaces;

namespace OnlineTest.Models.Repository
{
    public class RTokenRepository : IRTokenRepository
    {
        private readonly OnlineTestContext _context;
        public RTokenRepository(OnlineTestContext context)
        {
            _context = context;
        }

        public RToken GetRefreshToken(int id, string refreshToken)
        {
            return _context.rTokens.FirstOrDefault(x => x.UserId == id && x.RefreshToken == refreshToken);
        }

        public bool AddRefreshToken(RToken token)
        {
            _context.rTokens.Add(token);
            return _context.SaveChanges() > 0;
        }

        public bool ExpireRefreshToken(RToken token)
        {
            _context.Entry(token).Property("IsStop").IsModified = true;
            return _context.SaveChanges() > 0;
        }
    }
}
