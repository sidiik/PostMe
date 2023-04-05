using MediatR;
using ReactivitiesV1.Core;
using ReactivitiesV1.Data;
using ReactivitiesV1.Services;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace ReactivitiesV1.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(GetAll.Handler));
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));
            });

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreatePost>();

            return services;
        }
    }
}