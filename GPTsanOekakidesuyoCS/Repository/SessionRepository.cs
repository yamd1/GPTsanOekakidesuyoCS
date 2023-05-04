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

        public async Task<ActionResult<Models.Session>> FindById(int id)
        {
            return await _context.Sessions
                .Include(s => s.Messages)
                .FirstOrDefaultAsync(s => s.Id == id);
        }
    }
}
