
using Microsoft.EntityFrameworkCore;
using TestAspCore.Data.Interfaces;
using TestAspCore.Data.Mocks;
using TestAspCore.Data;
using TestAspCore.Data.Repository;
using TestAspCore.Migrations;
using TestAspCore.Data.Models;

namespace TestAspCore;

public class Startup
{

    private IConfigurationRoot _confString;

    public Startup(IHostEnvironment hostEnv)
    {
        _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json")
            .Build();
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
        services.AddTransient<IAllGames, GameRepository>();
        services.AddTransient<IGamesCategory,CategoryRepository>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped(sp => Data.Models.ShopCart.GetCart(sp));

        services.AddMvc(option => option.EnableEndpointRouting = false);

        services.AddMemoryCache();
        services.AddSession();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseSession();
        app.UseStaticFiles();
        //app.UseMvcWithDefaultRoute();

        app.UseMvc(routes =>
        {
            routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            routes.MapRoute(name: "categoryFilter", template: "Game/{action}/{category?}", defaults: new { Controller = "Game", action = "List" });
        });

        using (var scope = app.ApplicationServices.CreateScope())
        {
            AppDbContent content = scope.ServiceProvider.GetRequiredService<AppDbContent>();
            DBObjects.Initial(content);
        }
    }
}