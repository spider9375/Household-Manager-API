using AutoMapper;
using HouseholdManagerApi.Interfaces.Repositories;
using HouseholdManagerApi.MapperProfiles;
using HouseholdManagerApi.Repositories;
using HouseholdManagerApi.Models;
using HouseholdManagerApi.Interfaces.Services;
using HouseholdManagerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddDbContext<HomeInventoryContext>();

//Repositories
builder.Services.AddScoped<ISavingRepository, SavingRepository>();
//

//Services
builder.Services.AddScoped<ISavingService, SavingService>();
//

//AutoMapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<SavingProfile>();
});

builder.Services.AddAutoMapper(typeof(Program));
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();
