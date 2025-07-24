using Eag.Jwt.Onion.Core.App.Interfaces;
using Eag.Jwt.Onion.Infrastructure.Persistence.Context;
using Eag.Jwt.Onion.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Infrastructure.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JwtContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
