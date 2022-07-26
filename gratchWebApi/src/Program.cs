using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

Action<DbContextOptionsBuilder?> PostgreSQLBuilder = (DbContextOptionsBuilder? dbbuilder) => 
    dbbuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONNECTION"));

// Add services to the container.

builder.Services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings
                                                     .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<gratch.Api.Data.ApiDbContext>(PostgreSQLBuilder);

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
