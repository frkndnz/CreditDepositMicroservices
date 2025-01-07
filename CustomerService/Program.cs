using CustomerService.Data;
using Microsoft.EntityFrameworkCore;
using CustomerService.Utilities.Concrete;
using CustomerService.Models;
using CustomerService.MappingProfile;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);
builder.Services.AddDbContext<Context>(options =>
options.UseInMemoryDatabase("CustomerDb"));

builder.Services.AddServices();

var app = builder.Build();

using (var scope=app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Context>();

    var customer = new Customer()
    {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "test@gmail.com"
    };
   await context.Customers.AddAsync(customer);
   await context.SaveChangesAsync();
}

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
