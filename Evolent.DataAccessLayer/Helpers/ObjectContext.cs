using Evolent.Models.DBModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Evolent.DataAccessLayer.Helpers
{
    public class ObjectContext
    {
        public SqlConnection _connection = null;
        public ObjectContext(IOptions<Settings> settings, IConfiguration Configuration)
        {
            Configuration = settings.Value.iconfigurationRoot;
           
            {
                _connection = new SqlConnection(settings.Value.DatabaseConnectionString);
            }
        }
    }
}
