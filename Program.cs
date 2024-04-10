using AutoMapper;
using HouseholdManagerApi.Interfaces.Repositories;
using HouseholdManagerApi.MapperProfiles;
using HouseholdManagerApi.Repositories;
using HouseholdManagerApi.Models;
using HouseholdManagerApi.Interfaces.Services;
using HouseholdManagerApi.Services;
using System.Text.Json;

//scaffold
// Scaffold-DbContext "Server=127.0.0.1;Port=3306;Database=homeInventory;Uid=test-inventory;Pwd=112233" MySql.EntityFrameworkCore -OutputDir Models -f

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
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<IITemRepository, ItemRepository>();
//

//Services
builder.Services.AddScoped<ISavingService, SavingService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IItemService, ItemService>();
//

//AutoMapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<SavingProfile>();
    cfg.AddProfile<TagProfile>();
    cfg.AddProfile<ItemProfile>();
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
