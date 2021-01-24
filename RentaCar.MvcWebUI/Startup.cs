using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using RentaCar.Business.Abstract;
using RentaCar.Business.Concrete;
using RentaCar.DataAccess.Abstract;
using RentaCar.DataAccess.Concrete;

namespace RentaCar.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IUnitofWork,UnitofWork>();
            //services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IEmployeeService, EmployeeManager>();
            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IRentalService, RentalManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
