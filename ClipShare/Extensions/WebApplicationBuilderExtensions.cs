using ClipShare.DataAccess.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClipShare.Extensions
{
    public static class WebApplicationBuilderExtensions
    {
        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DbConnection");       // Database connection string

            // Add DBContext to the container.
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            // builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            // builder.Services.AddScoped<IPhotoService, PhotoService>();
            // builder.Services.AddSession();
            // builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return builder;
        }
    }
}
