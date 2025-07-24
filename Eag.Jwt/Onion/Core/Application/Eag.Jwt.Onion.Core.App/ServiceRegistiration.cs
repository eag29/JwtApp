using AutoMapper;
using Eag.Jwt.Onion.Core.App.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eag.Jwt.Onion.Core.App
{
    public static class ServiceRegistiration
    {
        public static void AddAplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new CategoryProfile(),
                    new ProductProfile(),
                    new AppUserProfile()
                });
            });
        }
    }
}
