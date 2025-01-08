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

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<Context>();

    var customers = new Customer[]
    {
       new Customer()
       {
        Id = 1,
        FirstName = "John",
        LastName = "Doe",
        Email = "test@gmail.com",
        PhoneNumber = "1234567890",
        Address="bahcelievler mah. 123 sokak no:5"

       },
       new Customer()
       {
           Id = 2,
              FirstName = "Jane",
                LastName = "Doe",
                Email = "test2@gmail.com",
                PhoneNumber="0987654321",
                Address="bahcelievler mah. 123 sokak no:5"
       }
    };
    await context.Customers.AddRangeAsync(customers);
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
