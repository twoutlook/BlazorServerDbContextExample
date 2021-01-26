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
using DreamAITek.T001.Adapter;

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



            services.AddScoped<A000Adapter>(); //原型
            services.AddScoped<A999Adapter>(); //特別給 頁面的原型使用
            services.AddScoped<A998Adapter>(); //特別給 doing ...使用


            services.AddScoped<A001Adapter>();
            services.AddScoped<A002Adapter>();
            services.AddScoped<A003Adapter>();
            services.AddScoped<A004Adapter>();
            services.AddScoped<A005Adapter>();
            services.AddScoped<A006Adapter>();
            services.AddScoped<A007Adapter>();
            services.AddScoped<A008Adapter>();
            services.AddScoped<A009Adapter>();
            services.AddScoped<A010Adapter>();
            services.AddScoped<A011Adapter>();
            services.AddScoped<A012Adapter>();
            services.AddScoped<A013Adapter>();
            services.AddScoped<A014Adapter>();
            services.AddScoped<A015Adapter>();
            services.AddScoped<A016Adapter>();
            services.AddScoped<A017Adapter>();
            services.AddScoped<A018Adapter>();
            services.AddScoped<A019Adapter>();
            services.AddScoped<A020Adapter>();
            services.AddScoped<A021Adapter>();
            services.AddScoped<A022Adapter>();
            services.AddScoped<A023Adapter>();
            services.AddScoped<A024Adapter>();
            services.AddScoped<A025Adapter>();
            services.AddScoped<A026Adapter>();
            services.AddScoped<A027Adapter>();
            services.AddScoped<A028Adapter>();
            services.AddScoped<A029Adapter>();
            services.AddScoped<A030Adapter>();
            services.AddScoped<A031Adapter>();
            services.AddScoped<A032Adapter>();
            services.AddScoped<A033Adapter>();
            services.AddScoped<A034Adapter>();
            services.AddScoped<A035Adapter>();
            services.AddScoped<A036Adapter>();
            services.AddScoped<A037Adapter>();
            services.AddScoped<A038Adapter>();
            services.AddScoped<A039Adapter>();
            services.AddScoped<A040Adapter>();
            services.AddScoped<A041Adapter>();
            services.AddScoped<A042Adapter>();
            services.AddScoped<A043Adapter>();
            services.AddScoped<A044Adapter>();
            services.AddScoped<A045Adapter>();
            services.AddScoped<A046Adapter>();
            services.AddScoped<A047Adapter>();
            services.AddScoped<A048Adapter>();
            services.AddScoped<A049Adapter>();
            services.AddScoped<A050Adapter>();
            services.AddScoped<A051Adapter>();
            services.AddScoped<A052Adapter>();
            services.AddScoped<A053Adapter>();
            services.AddScoped<A054Adapter>();
            services.AddScoped<A055Adapter>();
            services.AddScoped<A056Adapter>();
            services.AddScoped<A057Adapter>();
            services.AddScoped<A058Adapter>();
            services.AddScoped<A059Adapter>();
            services.AddScoped<A060Adapter>();
            services.AddScoped<A061Adapter>();
            services.AddScoped<A062Adapter>();
            services.AddScoped<A063Adapter>();
            services.AddScoped<A064Adapter>();
            services.AddScoped<A065Adapter>();
            services.AddScoped<A066Adapter>();
            services.AddScoped<A067Adapter>();
            services.AddScoped<A068Adapter>();
            services.AddScoped<A069Adapter>();
            services.AddScoped<A070Adapter>();
            services.AddScoped<A071Adapter>();
            services.AddScoped<A072Adapter>();
            services.AddScoped<A073Adapter>();
            services.AddScoped<A074Adapter>();
            services.AddScoped<A075Adapter>();
            services.AddScoped<A076Adapter>();
            services.AddScoped<A077Adapter>();
            services.AddScoped<A078Adapter>();
            services.AddScoped<A079Adapter>();
            services.AddScoped<A080Adapter>();
            services.AddScoped<A081Adapter>();
            services.AddScoped<A082Adapter>();
            services.AddScoped<A083Adapter>();
            services.AddScoped<A084Adapter>();
            services.AddScoped<A085Adapter>();
            services.AddScoped<A086Adapter>();
            services.AddScoped<A087Adapter>();
            services.AddScoped<A088Adapter>();
            services.AddScoped<A089Adapter>();
            services.AddScoped<A090Adapter>();
            services.AddScoped<A091Adapter>();
            services.AddScoped<A092Adapter>();
            services.AddScoped<A093Adapter>();
            services.AddScoped<A094Adapter>();
            services.AddScoped<A095Adapter>();
            services.AddScoped<A096Adapter>();
            services.AddScoped<A097Adapter>();
            services.AddScoped<A098Adapter>();
            services.AddScoped<A099Adapter>();

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
