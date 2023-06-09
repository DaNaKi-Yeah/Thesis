﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Persistence.Intrefaces;
using Thesis.Persistence.Repositories;

namespace Thesis.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSQLDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<ThesisDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient(typeof(IRepository<,>), typeof(BaseRepository<,>));
            return services;
        }
    }
}
