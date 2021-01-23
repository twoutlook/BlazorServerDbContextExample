using Inventory.Areas.Identity;
using Inventory.Data;
using Inventory.Grid;
using Inventory.Grid.Part;
using Inventory.Grid.Location;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.Grid.Adjust;
using Inventory.Grid.Parameter;
using DreamAITek.T001;

namespace Inventory
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

          //  services.AddMemoryCache();
            //services.AddDbContext<TaiweiContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("TaiweiConnection")));


            services.AddDbContextFactory<TaiweiContext>(opt =>
                opt.UseSqlServer(
                    Configuration.GetConnectionString("TaiweiConnection")));

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddRazorPages();
            services.AddServerSideBlazor();
        //    services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            //services.AddSingleton<WeatherForecastService>();



            // pager
            //services.AddScoped<IPartPageHelper, PartPageHelper>();
            //services.AddScoped<IPageHelper, PageHelper>(); // DOING ...for Loation and general usage 

            // filters
            services.AddScoped<IPartFilters, PartFilters>();
            services.AddScoped<ILocationFilters, LocationFilters>();
            services.AddScoped<IAdjustFilters, AdjustFilters>();
            services.AddScoped<IParameterFilters, ParameterFilters>();
            services.AddScoped<IBaseFilters, BaseFilters>();
            services.AddScoped<IFilters997, Filters997>();
            //  'Inventory.Grid.Adjust.AdjustFilters' 
            //   services.AddScoped<IAppFilters, AppFilters>();



            // query adapter (applies filter to contact request).
            services.AddScoped<PartGridQueryAdapter>();
            services.AddScoped<LocationGridQueryAdapter>();
            //            services.AddScoped<LocationGridQueryAdapterV2>();
            services.AddScoped<AdjustGridQueryAdapter>();
            services.AddScoped<ParameterGridQueryAdapter>();
            services.AddScoped<Q005InbillGridQueryAdapter>();
            services.AddScoped<Q006OutbillGridQueryAdapter>();
            services.AddScoped<Q007SysConfigGridQueryAdapter>();
            services.AddScoped<Q008OutbillDGridQueryAdapter>();
            services.AddScoped<Q009V2OutbillDGridQueryAdapter>();
            services.AddScoped<Q010BaseOperatorGridQueryAdapter>();
            services.AddScoped<Q011VCmdMstGridQueryAdapter>();
            services.AddScoped<Q012BaseDocureasonGridQueryAdapter>();
            services.AddScoped<Q013VInoutTypeGridQueryAdapter>();
            services.AddScoped<Q014V2OutbillAdapter>();
            services.AddScoped<Q015V2StockCurrentAdapter>();
            services.AddScoped<Q021SysParameterAdapter>();
            services.AddScoped<Q999DynamicAdapter>();
            services.AddScoped<Q998DynamicAdapter>();
            services.AddScoped<Q997DynamicAdapter>();
            services.AddScoped<Q029Adapter>();
            services.AddScoped<Q028Adapter>();
            services.AddScoped<Q030Adapter>();


// ============ T001 A001
            services.AddScoped<IFiltersA000, FiltersA000>();

            services.AddScoped<A001Adapter>();
            services.AddScoped<A002Adapter>();
            services.AddScoped<A003Adapter>();
            services.AddScoped<A004Adapter>();
            services.AddScoped<A005Adapter>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
