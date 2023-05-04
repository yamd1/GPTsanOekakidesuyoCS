using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GPTsanOekakidesuyoCS.Models;

namespace GPTsanOekakidesuyoCS.Data
{
    public class GPTsanOekakidesuyoCSContext : DbContext
    {
        public GPTsanOekakidesuyoCSContext (DbContextOptions<GPTsanOekakidesuyoCSContext> options)
            : base(options)
        {
        }

        public DbSet<GPTsanOekakidesuyoCS.Models.Session> Sessions { get; set; } = default!;
        public DbSet<GPTsanOekakidesuyoCS.Models.Message> Messages { get; set; } = default!;
    }
}
