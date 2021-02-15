using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Recruitment.Data;
using Recruitment.Repository;
using Recruitment.Repository.ApplicantRepo;
using Recruitment.Repository.ApplicationRepo;
using Recruitment.Repository.VacancyRepo;
using Recruitment.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Recruitment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration["ConnectionString"];

            services.AddIdentity<User, Role>()
               .AddEntityFrameworkStores<DataContext>()
               .AddDefaultTokenProviders();

            services.AddDbContext<DataContext>(options =>
            {
                // Configure the context to use Microsoft SQL Server.
                options.UseSqlServer(connectionString, m =>
                {
                    m.MigrationsAssembly(typeof(Startup).Assembly.FullName);
                    m.EnableRetryOnFailure(5);
                });

                // Register the entity sets needed by OpenIddict.
                // Note: use the generic overload if you need
                // to replace the default OpenIddict entities.
                //options.UseOpenIddict<long>();
            });

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IVacancyRepository, VacancyRepository>();
            services.AddScoped<IApplicantRepository, ApplicantRepository>();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CBT_1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CBT_1 v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            CreateUserRoles(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();

            var user = new User() { Email = Constants.Email, UserName = Constants.UserName };
            //var user = new User() { Email = "admin@gmail.com", UserName = "admin" };

            var result = await UserManager.CreateAsync(user, Constants.AdminPassword);
            await UserManager.AddClaimAsync(user, new Claim("sub", user.Id.ToString()));

           

        }
        // This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{

        //    services.AddControllers();
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Recruitment", Version = "v1" });
        //    });
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseSwagger();
        //        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recruitment v1"));
        //    }

        //    app.UseRouting();

        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //    });
        //}
    }
}
