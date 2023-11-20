using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi
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
    string connectionString = Configuration.GetConnectionString("ToDoContext");
    services.AddDbContext<TodoContext>(op => op.UseSqlServer(connectionString));

    services.AddControllersWithViews();
}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
     
public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseDefaultFiles();
    app.UseStaticFiles();


    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthorization();
    app.UseAuthentication();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
}

}
}
