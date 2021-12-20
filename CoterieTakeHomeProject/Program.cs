global using CoterieTakeHomeProject.Classes;
global using CoterieTakeHomeProject.Classes.Factors;
global using CoterieTakeHomeProject.Classes.FactorSources;
global using CoterieTakeHomeProject.Controllers;
global using CoterieTakeHomeProject.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton(typeof(IFactorSource<BusinessFactor>), new StaticBusinessFactorSource());
builder.Services.AddSingleton(typeof(IFactorSource<StateFactor>), new StaticStateFactorSource());
builder.Services.AddSingleton(typeof(IFactorSource<HazardFactor>), new StaticHazardFactorSource());
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
