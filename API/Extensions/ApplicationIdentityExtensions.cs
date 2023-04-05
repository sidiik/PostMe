using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Domain;
using ReactivitiesV1.Data;

namespace API.Extensions
{
    public static class ApplicationIdentityExtensions
    {
        public static IServiceCollection AddApplicationIdentityServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<DataContext>();

            return services;
        }
    }
}