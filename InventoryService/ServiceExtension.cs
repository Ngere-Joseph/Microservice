using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InventoryService;
public static class ServiceExtensions
{
    public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
    }

    public static void ConfigureServiceADbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Data.ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("OrderService")));
    }

    public static void ConfigureServiceBDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProductSevice.Data.ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ProductService")));
    }

    public static void ConfigureServiceBClient(this IServiceCollection services)
    {
        services.AddHttpClient<OrderService.Services.ProductService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:5001"); // Prodxct service base url
        });
    }
}
