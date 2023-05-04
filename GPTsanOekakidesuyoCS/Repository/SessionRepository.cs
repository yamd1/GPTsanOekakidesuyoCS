using GPTsanOekakidesuyoCS.Data;
using GPTsanOekakidesuyoCS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.OpenApi.Any;
using NuGet.Protocol.Core.Types;

public interface ISessionRepository 
{
    Task<ActionResult<Session>> FindById(int id);
    Task<ActionResult<List<Session>>> FindAll();
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

        /**
         * session id でDBを検索する
         * SELECT * FROM sessions JOIN messages ON sessions.id = messages.sessionId WHERE sessions.id = :id;
         */
        public async Task<ActionResult<Models.Session>> FindById(int id)
        {
            return await _context.Sessions
                .Include(s => s.Messages)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<ActionResult<List<Models.Session>>> FindAll()
        { 
            return await _context.Sessions.ToListAsync();
        }
    }
}
