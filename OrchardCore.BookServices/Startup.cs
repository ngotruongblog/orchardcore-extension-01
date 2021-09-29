using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.BookServices.Controllers;
using OrchardCore.BookServices.Models;
using OrchardCore.BookServices.Permissions;
using OrchardCore.BookServices.Services;
using OrchardCore.Modules;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Security.Permissions;

namespace OrchardCore.BookServices
{
    public class Startup: StartupBase
    {
        private readonly AdminOptions _adminOptions;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, 
            IOptions<AdminOptions> adminOptions)
        {
            Configuration = configuration;
            _adminOptions = adminOptions.Value;
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ConnectionStrings>(Configuration.GetSection("ConnectionStrings"));
            services.AddControllers();
            services.AddScoped<IPermissionProvider, PermissionCollection>();
            services.AddScoped<IBookService, BookServiceImpl>();
        }
        public override void Configure(IApplicationBuilder builder, 
            IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            builder.UseRouting();
            routes.MapAreaControllerRoute(
                name: "BookService",
                areaName: "OrchardCore.BookService",
                pattern: _adminOptions.AdminUrlPrefix + "/book",
                defaults: new { controller = typeof(BookController).ControllerName(), 
                    action = nameof(BookController.Index) }
            );
        }
    }
}
