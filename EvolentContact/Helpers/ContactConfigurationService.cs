using Evolent.BusinessLayer.Interface;
using Evolent.BusinessLayer.Repository;
using Evolent.DataAccessLayer.Services;
using Evolent.Models.DBModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvolentContact.Helpers
{
    public class ContactConfigurationService
    {
        public IConfigurationRoot Configuration { get; set; }
        public IServiceCollection Services { get; set; }

        private static ContactConfigurationService _Instance;
        public static ContactConfigurationService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ContactConfigurationService();
                }
                return _Instance;
            }

        }
        public ContactConfigurationService()
        {

        }
        public void BuildConfig(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void BuildTestConfig(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(env.ContentRootPath)
              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
              .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        internal void BuildServices(IServiceCollection services)
        {

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //services.Configure<Settings>(o => { o.iconfigurationRoot = Configuration; });
            //services.Configure<Settings>(o => { o.DatabaseConnectionString = Configuration["SqlConnection:ConnectionString"]; });


            //services.AddTransient<IContact, ContactRepository>();

            services.AddDbContext<ContactDataAccess>(option => option.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));
      
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }
    }
}
