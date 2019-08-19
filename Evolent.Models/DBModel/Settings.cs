using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evolent.Models.DBModel
{
    public class Settings
    {
        public string DatabaseConnectionString;
        public string Database;
        public IConfigurationRoot iconfigurationRoot;
    }
}
