using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RentaCar.DataAccess.Concrete.EntityFramework;

namespace RentaCar.MvcWebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var rentalContext = new RentaCarContext())
            {
                foreach(var customer in rentalContext.Customers)
                {
                    Console.WriteLine("Customer Name: {0}", customer);
                }
            }
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
