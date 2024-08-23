using AgoraDotNet.Infrastructure.Persistence;
using AgoraDotNet.Infrastructure.Persistence.DbContext;
using Fleck;
using Microsoft.EntityFrameworkCore;

var wsServer = new WebSocketServer("ws://0.0.0.0:8181");
wsServer.Start(ws =>
{
    ws.OnMessage = message =>
    {
        Console.WriteLine(message);
    };
});

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// singletons
// builder.Services.AddSingleton<GameServerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); 

app.MapControllers();

app.Run();
