

using InventoryService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Custom service configurations
builder.Services.ConfigureJwtAuthentication(builder.Configuration);
builder.Services.ConfigureServiceADbContext(builder.Configuration); // For ServiceA
builder.Services.ConfigureServiceBClient(); // For ServiceA

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
