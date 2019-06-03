using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using storecore.backend.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace storecore.backend
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "StoreCore API", Version = "v1" });
            });

            //services.AddDbContext<StoreContext>(ops => ops.UseMySql(@"Server=localhost; Database=StoreCore; Uid=user_name_1; Pwd=my-secret-pw"));

            services.AddDbContext<StoreContext>(ops =>
            {
                ops.UseInMemoryDatabase("Store");
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, StoreContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "StoreCore API V1");
            });

            //context.Database.Migrate();
            app.UseMvc();
        }
    }
}
