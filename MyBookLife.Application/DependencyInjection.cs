using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyBookLife.Application.Interfaces;
using MyBookLife.Application.Services;
using MyBookLife.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLife.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IDiaryService, DiaryService>();
            services.AddTransient<IEntryService, EntryService>();
            services.AddTransient<IGenreService, GenreService>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
