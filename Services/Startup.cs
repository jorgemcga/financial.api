using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using Financial.API.Common.Data;
using Financial.API.Common.Repositories;
using Financial.API.Common.Services;
using Financial.API.Core.Services;
using Financial.API.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Financial.API.Services
{
    public partial class Startup
    {
        private string _connectionString { get; set; }

        public IHostingEnvironment HostingEnvironment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            HostingEnvironment = env;
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddSwaggerGen();
            
            services.AddEntityFrameworkSqlServer()
               .AddDbContext<Context>(opt => opt.UseSqlServer(_connectionString));

            services.AddScoped<IExpiredTitleRepository, ExpiredTitleRepository>();
            services.AddScoped<IExpiredTitleService, ExpiredTitleService>();
            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expired Title API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}