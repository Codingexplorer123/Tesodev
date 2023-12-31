using Microsoft.EntityFrameworkCore;
using TesodevCase.DAL.Context;
using TesodevCase.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
builder.Services.AddDbContext<CustomerDbContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnectionString")));
// Serviceleri build etmeden once database baglantisi icin gerekli olan connection stringimizi servislere kaydettik.
builder.Services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddCustomerServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
