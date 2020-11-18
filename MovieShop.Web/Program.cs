using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
    //Kestrel server...
    //main method is the entry point which will create a hosting environment so that ASP.NET Core can work inside that one.
    //If something is wrong , first place to look for is startup class

    //Middleware is new ASP.NET Core
    //When you make a request in ASP.NET core MVC/API. The request will go through middleware
    //Request ->M1 -> some processing ->M2 --> M3 --> Destination
    //Response --> M3 --> M2 --> M1
    //ASP.NET Core has some built-in middlewares where every requedst will go through those middleware.
    //We as a developer can create our own custom MiddlwWare also plug in to pipeline.

    //Routing -->Patten matching technique. Traditional based routing
    // http://example.com/Students/List/2019/Dec
    //Attribute based routing --> most used one.
}
