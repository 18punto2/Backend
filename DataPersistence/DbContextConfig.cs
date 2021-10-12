using System;
using System.Collections.Generic;
using System.Text;

namespace DataPersistence
{
    public class DbContextConfig
    {
        public string Connection { get; set; }
        public DbContextConfig(string connetionString) => Connection = connetionString;
        
    }
}
