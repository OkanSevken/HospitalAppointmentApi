using HospitalApi.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalApi.Application.Interfaces.Repositories;
using HospitalApi.Persistence.Repositories;
using HospitalApi.Application.Interfaces.UnitOfWorks;
using HospitalApi.Persistence.UnitOfWorks;

namespace HospitalApi.Persistence
{
    public static class Registration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
