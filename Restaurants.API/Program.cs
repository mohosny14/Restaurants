using Restaurants.Infrastructure.Persistence;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

#region Add services to the container
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
#endregion

var app = builder.Build();

#region Seeding Database
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();
await seeder.SeedAsync();
#endregion

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
