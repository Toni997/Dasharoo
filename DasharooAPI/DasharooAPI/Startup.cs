using AspNetCoreRateLimit;
using Autofac;
using AutoMapper;
using DasharooAPI.Configurations;
using DasharooAPI.Controllers;
using DasharooAPI.Data;
using DasharooAPI.HubConfig;
using DasharooAPI.IRepository;
using DasharooAPI.Repository;
using DasharooAPI.Services;
using DasharooAPI.Services.Auth;
using DasharooAPI.Services.Genres;
using DasharooAPI.Services.Playlists;
using DasharooAPI.Services.Records;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DasharooAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDbContext(Configuration);

            services.AddMemoryCache();

            services.ConfigureRateLimiting();
            services.AddHttpContextAccessor();

            // services.ConfigureHttpCacheHeaders();

            // services.AddAuthentication().AddFacebook(facebookOptions =>
            // {
            //     facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
            //     facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            // });
            services.ConfigureIdentity();
            services.ConfigureJwt(Configuration);

            services.ConfigureCors();

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            services.AddTransient<IMessageService, EmailService>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRecordRepository, RecordRepository>();
            services.AddTransient<IPlaylistRepository, PlaylistRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IGenericRepository<RefreshToken>, GenericRepository<RefreshToken>>();
            services.AddTransient<IGenericRepository<RecordGenre>, GenericRepository<RecordGenre>>();
            services.AddTransient<IGenericRepository<RecordAuthor>, GenericRepository<RecordAuthor>>();
            services.AddTransient<IGenericRepository<RecordPlaylist>, GenericRepository<RecordPlaylist>>();
            services.AddTransient<IGenericRepository<AuthorFollower>, GenericRepository<AuthorFollower>>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IRecordService, RecordService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IPlaylistService, PlaylistService>();
            services.AddTransient<IMyHub, MyHub>();
            services.AddTransient<IAuthService, AuthService>();

            services.AddScoped<IAuthManager, AuthManager>();

            services.ConfigureSwagger();

            services.AddSignalR();

            services.ConfigureControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DasharooAPI v1"));

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors();

            // app.UseResponseCaching();
            // app.UseHttpCacheHeaders();
            app.UseIpRateLimiting();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<MyHub>("/myhub");
            });
        }
    }
}
