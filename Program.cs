using Scalar.AspNetCore;
// using Microsoft.EntityFrameworkCore;
using kredibu_server.Data;
using Microsoft.EntityFrameworkCore;
using kredibu_server.Repositories;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var connectionString=builder.Configuration.GetConnectionString("DefaultConnection");
// var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
// Add services to the container.
var services = builder.Services;
services.AddControllers();
services.AddDbContext<UserDbContext>(opt => opt.UseNpgsql(connectionString));



// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddScoped<IAuthRepository, AuthServices>();
services.AddOpenApi();
// builder.Services.AddDbContext<UserDbContext>(opt => opt.UseInMemoryDatabase("IndividualUser"));
services.AddHttpClient(name: "NorthwindService", configureClient: options =>
{
    options.BaseAddress = new Uri("https://google.com");
    options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
