using ForumWeb.Areas.Identity.Data;
using ForumWeb.Data;
using ForumWeb.Gateway;
using ForumWeb.Models.IModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumWeb
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

            services.AddHttpClient<CategoryGateWay>();
            services.AddScoped<ICategory, CategoryGateWay>();

            services.AddHttpClient<SubCategoryGateWay>();
            services.AddScoped<ISubCategory, SubCategoryGateWay>();

            services.AddHttpClient<PostGateWay>();
            services.AddScoped<IPost, PostGateWay>();

            services.AddHttpClient<CommentGateWay>();
            services.AddScoped<IComment, CommentGateWay>();

            services.AddHttpClient<ReportGateWay>();
            services.AddScoped<IReport, ReportGateWay>();

            services.AddHttpClient<MessageGateWay>();
            services.AddScoped<IMessage, MessageGateWay>();

            //COOKIES
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
           

            services.AddAuthorization(options =>
            {
                options.AddPolicy("BeAdmin",
                    policy => policy.RequireRole("Admin"));
            });

            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin", "BeAdmin");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
