using ApplicationCore.Interface;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container 2. 
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
) ;




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationDbContext>( options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PSQL"));
});

builder.Services.AddTransient<IVideoGameRepository, VideoGameRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapGet("genre", (ApplicationDbContext context) =>context.genre.ToList());
app.MapGet("game", (ApplicationDbContext context) => context.game.Include( e => e.genre ).ToList());
app.MapGet("region", (ApplicationDbContext context) => context.region.ToList());

app.MapControllers();

app.Run();
