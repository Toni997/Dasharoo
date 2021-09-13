using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;
using DasharooAPI.Data;
using DasharooAPI.Services.Genres;

namespace DasharooAPI.Configurations
{
    public class AutofacConfiguration
    {
        public static void Configure()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<GenreService>().As<IGenreService>();
            var container = containerBuilder.Build();

            var genreService = container.Resolve<IGenreService>();
        }
    }
}
