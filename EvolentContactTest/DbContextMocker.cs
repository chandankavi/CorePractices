using Evolent.DataAccessLayer.Services;
using EvolentContact;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvolentContactTest
{
    public class DbContextMocker
    {
        //public DbContextMocker(IHostingEnvironment env) : base(env)
        //{
        //}

        //public override void ConfigureServices(IServiceCollection services)
        //{
        //    services

        //        .AddDbContext<ContactDataAccess>((options) =>
        //        {
        //            options.UseInMemoryDatabase("EvolentContact");
        //        });
        //    base.ConfigureServices(services);
        //}

        public static ContactDataAccess GetContactDataAccess(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<ContactDataAccess>().UseInMemoryDatabase(dbName)
                        .Options;

            // Create instance of DbContext
            
            var dbContext = new ContactDataAccess(options);

           

            return dbContext;
        }
    }
}
