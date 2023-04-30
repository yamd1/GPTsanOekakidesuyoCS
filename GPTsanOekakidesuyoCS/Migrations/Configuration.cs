using GPTsanOekakidesuyoCS.Data;
using GPTsanOekakidesuyoCS.Models;

namespace GPTsanOekakidesuyoCS.Migrations
{
    protected void Seed(GPTsanOekakidesuyoCSContext context)
    {
        context.Session.Add(
            new Session() { Id = 1, Name = "Test1" }
            //new Session() { Id = 2, Name = "Test2" },
            //new Session() { Id = 3, Name = "Test3" }
            );
    }
}
