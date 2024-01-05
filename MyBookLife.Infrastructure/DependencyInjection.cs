 using Microsoft.Extensions.DependencyInjection;
using MyBookLife.Domain.Interfaces;
using MyBookLife.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IDiaryRepository, DiaryRepository>();
            services.AddTransient<IEntryRepository, EntryRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();

            return services;
        }
    }
}
