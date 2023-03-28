using lab.Contracts;
using lab.Data;
using lab.MapperConfigs;
using lab.Middleware;
using lab.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<restaurantsContext>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped<IClientsRepository, ClientsRepository>();
builder.Services.AddScoped<IDeliveryTypeRepository, DeliveryTypeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
