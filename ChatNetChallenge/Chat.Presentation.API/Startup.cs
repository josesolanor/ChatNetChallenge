using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chat.Application.Commands;
using Chat.Application.Interfaces;
using Chat.Application.Mapper;
using Chat.Application.Models;
using Chat.Application.Queries;
using Chat.Application.Services;
using Chat.Domain.Entities;
using Chat.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Chat.Presentation.API
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
            services.AddInfrastructure(Configuration);
            services.AddAutoMapper(configuration =>
            {
                configuration.AddProfile(new MappingProfile());                                
            }, typeof(Startup));
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();

            services.AddTransient<IUserCommands<UserDTO>, UserCommands>();
            services.AddTransient<IUserQueries<UserDTO>, UserQueries>();
            services.AddTransient<IMessageCommands<MessageDTO>, MessageCommands>();
            services.AddTransient<IMessageQueries<MessageDTO>, MessageQueries>();
            services.AddTransient<ILoginQueries<LoginDTO>, LoginQueries>();
            services.AddTransient<IStockBotApi, StockBotApi>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
