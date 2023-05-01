using GPTsanOekakidesuyoCS.Data;
using GPTsanOekakidesuyoCS.Models;
using Microsoft.EntityFrameworkCore;

public class DbInitializer
{
    public static async Task SeedingAsync(GPTsanOekakidesuyoCSContext context)
    {
        await context.Database.EnsureCreatedAsync();
        if (await context.Session.AnyAsync())
            return;
        await context.Session.AddRangeAsync(
            new Session { Name = "Test1 ", CreatedAt = new DateTime(2023-05-01), UpdatedAt = null},
            new Session { Name = "Test2 ", CreatedAt = new DateTime(2023-05-01), UpdatedAt = null},
            new Session { Name = "Test3 ", CreatedAt = new DateTime(2023-05-01), UpdatedAt = null}
            );
        await context.Message.AddRangeAsync(
            new Message { SessionsId = 1, Role = "user", Content = "Test User Content1", CreatedAt = new DateTime(2023 - 05 - 01), UpdatedAt = null },
            new Message { SessionsId = 1, Role = "assistant", Content = "Test Assistant Content1", CreatedAt = new DateTime(2023 - 05 - 01), UpdatedAt = null }
            );
        await context.SaveChangesAsync();
    }
}
