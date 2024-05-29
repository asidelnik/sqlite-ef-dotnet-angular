using Microsoft.EntityFrameworkCore;
using sqlink.Data;
using sqlink.Services.IRepositories;
using sqlink.Services.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<InsuranceDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
  .AllowAnyMethod()
  .AllowAnyHeader()
  .AllowCredentials()
  //.WithOrigins("https://localhost:5195))
  .SetIsOriginAllowed(origin => true)
);

app.MapControllers();
app.Run();