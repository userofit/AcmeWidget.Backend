using Acme.Infrastructure;
using Acme.Repository;
using Acme.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acme
{
    public class Startup
    {
        private string[] corsOrigins = { "*" };
        private string CorsPolicyName = "AllowCorsOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            var connectionString = Configuration.GetConnectionString("AcmeSQLConnection");
            services.AddDbContext<AcmeDbContext>(
                options => options.UseSqlServer(connectionString)
            );
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISignupRepository, SignupRepository>();
            services.AddScoped<IAcmeUnitOfWork, AcmeUnitOfWork>();
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName, builder => builder.WithOrigins(corsOrigins).AllowAnyHeader().AllowAnyMethod());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsPolicyName);
            app.UseMvc();
        }
    }
}
