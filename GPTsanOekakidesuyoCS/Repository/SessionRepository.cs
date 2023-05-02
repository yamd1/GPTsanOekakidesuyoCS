using GPTsanOekakidesuyoCS.Data;
using NuGet.Protocol.Core.Types;

public interface ISessionRepository 
{
    Task<IQueryable> FindById(int id);
}

namespace GPTsanOekakidesuyoCS.Repository
{
    /**
     * DB問い合わせクラス
     */
    public class SessionRepository : ISessionRepository
    {
        /**
         * DBアクセスに用いるクライアントを初期化
         */
        private GPTsanOekakidesuyoCSContext _context;
        public SessionRepository(GPTsanOekakidesuyoCSContext context)
        {
            _context = context;
        }

        public async Task<IQueryable> FindById(int id)
        {
            var dbResponses =  _context.Session
                    .Join(_context.Message,
                        b => b.Id,
                        m => m.SessionsId,
                        (joinSession, joinMessage) => new 
                        {
                            Session = joinSession,
                            Message = joinMessage
                        }
                    )
                    .Where( e => e.Session.Id.Equals(id));
            return dbResponses;
        }
    }
}
