using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GPTsanOekakidesuyoCS.Data;
using GPTsanOekakidesuyoCS.Services;
using GPTsanOekakidesuyoCS.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GPTsanOekakidesuyoCSContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GPTsanOekakidesuyoCSContext") ?? throw new InvalidOperationException("Connection string 'GPTsanOekakidesuyoCSContext' not found.")));

builder.Services.AddTransient<ISessionRepository, SessionRepository>();
builder.Services.AddTransient<IGetSessionService, GetSessionService>();


var provider = builder.Services.BuildServiceProvider();
try
{
    var context = provider.GetRequiredService<GPTsanOekakidesuyoCSContext>();
    DbInitializer.SeedingAsync(context);
}
catch (Exception ex)
{
    var logger = provider.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "データベース初期化中エラー");
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
