using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieSite.App.Repositories;
using MovieSite.BLL;
using MovieSite.Data;
using MovieSite.Data.Repositories;

namespace MovieSite.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /*
         * ASP.NET Core reads in configuration from 4 or 5 sources when it starts up.
         *  sources:
         *      . command-line arguments
         *      . environment variables      (":" or "__" means indent one step)
         *      . "user secrets"                  (stored outside the solution folder)
         *      . appsettings.(environment).json     ("Development" environment in VS)
         *      . appsettings.json
         */

            /* put this in user secrets () */
            //{
            //  "ConnectionStrings": {
            //    "MovieDb": "(connection string here)"
            //  }
            //}

    public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // efault config to ask for consent for cookies
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // here we register the dependencies of our classes as services.


            // this line is used at runtime, but also when we run migrations (code-first)
            services.AddDbContext<MovieContext>(optionsBuilder =>
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MovieDb")));

            // means: if anyone needs a IMovieRepo, try to create a MovieRepo
            // (the "scoped" means, share the same instance within the lifecycle of one HTTP request)
            
            // dependency injection lets you easily switch which concrete implementaiton you want.
            //services.AddSingleton<IMovieRepo, MovieRepo>();
            services.AddSingleton<IMovieRepo, MovieDbRepo>();

            // means: if anyone needs a List<Movie>, run this lambda expression to make one
            services.AddSingleton(sp => new List<BLL.Movie>
            {
                new BLL.Movie { Id = 1, Title = "Toy Story 4", ReleaseYear = 2019 }
            });

            // there's also AddTransient (every time we need this service, make a new instance)
            // and AddSingleton (share one instance across the whole app forever)

            // config for MVC older-version compatibility modes
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
