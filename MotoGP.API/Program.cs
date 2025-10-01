using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MotoGP.API.DBContext;
using MotoGP.API.Strategies;
using MotoGP.API.Services;
using AutoMapper;
using MotoGP.API.MappingProfiles;
using MotoGP.API.Seeders; // Assuming you have a Profiles folder for AutoMapper profiles

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddScoped<IRaceDurationCalculator, LapsBasedCalculator>(); // Register LapsBasedCalculator
builder.Services.AddScoped<IRiderRepository, RiderRepository>();
builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>(); // Register TicketRepository
builder.Services.AddScoped<TicketSeeder>(); // Register TicketSeeder
// Add DbContext
builder.Services.AddDbContext<MotoGPContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MotoGPDBConnectionString"))
);

// Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler
    = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles)
    .AddNewtonsoftJson();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MotoGP API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
