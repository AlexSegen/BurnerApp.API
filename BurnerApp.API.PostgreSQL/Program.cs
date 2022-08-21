using BurnerApp.Data;
using BurnerApp.Data.Repository;
using BurnerApp.Data.Services;

var builder = WebApplication.CreateBuilder(args);


// PostgreSQL Injection
ConfigurationManager configuration = builder.Configuration;
var postgreSQLConnectionConfiguration = 
    new PostgreSQLConfiguration(configuration.GetConnectionString("PostgreSQLConnection"));
builder.Services.AddSingleton(postgreSQLConnectionConfiguration);

// Add repositories to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Add services to the container.
builder.Services.AddScoped<IUserService, UserService>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
