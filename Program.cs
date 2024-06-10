using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EventDrivenBookstoreAPI.Implementation;
using EventDrivenBookstoreAPI.Interface;

var builder = WebApplication.CreateBuilder(args);

// Configuration settings
var configuration = builder.Configuration;

// Register CosmosClient
builder.Services.AddSingleton<CosmosClient>(sp =>
{
    var endpointUrl = configuration["CosmosDb:Account"];
    var primaryKey = configuration["CosmosDb:Key"];
    if (string.IsNullOrEmpty(endpointUrl) || string.IsNullOrEmpty(primaryKey))
    {
        throw new InvalidOperationException("Cosmos DB configuration is missing or invalid.");
    }
    return new CosmosClient(endpointUrl, primaryKey);
});

// Register services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ISubscriberService, SubscriberService>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventDrivenBookstoreAPI v1");
        c.RoutePrefix = "swagger"; // Set the Swagger UI to be accessible at "/swagger"
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
