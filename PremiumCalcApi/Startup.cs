using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PremiumCalcApi.Common;
using PremiumCalcApi.ModelMapper;
using PremiumCalcApi.Models;
using PremiumCalcApi.Repository;
using PremiumCalcApi.Services;
using PremiumCalcApi.Validator;
using PremiumCalcApi.ViewModels;

namespace PremiumCalcApi
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
            services.Configure<AppSettings>(
                Configuration.GetSection("AppSettings"));

            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperConfig());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPremiumCalcuatorService, PremiumCalcuatorService>();
            services.AddTransient<IOccupationService, OccupationService>();

            services.AddScoped<IValidator<PremiumCalculator>, PremiumCalcValidator>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "FrontEndPolicy",
                    builder =>
                    {
                        builder.WithOrigins(Configuration.GetSection("AppSettings:FrontEndUrl").Value)
                            .AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddControllers();

            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Premium Calculator API",
                    Description = "Premium Calculator API",
                });
            });

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "FrontEnd/dist";
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           

            app.UseHttpsRedirection();

            app.UseCors("FrontEndPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
            });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "FrontEnd";

                if (env.IsDevelopment())
                {
                    //spa.UseAngularCliServer(npmScript: "start");
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");

                }
            });
        }
    }
}
