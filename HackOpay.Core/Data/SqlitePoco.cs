using System;
using System.Linq;
using System.Collections.Generic;
using HackOpay.Core.Domain;
using NPoco;
using NPoco.FluentMappings;
using System.Text;
using System.Threading.Tasks;

namespace HackOpay.Core.Data
{

    public class SqlitePoco
    {
        /// <summary>
        /// 
        /// </summary>
        public static DatabaseFactory DbFactory { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public static void Setup()
        {
            var fluentConfig = FluentMappingConfiguration.Configure(new SqliteMappings());
            DbFactory = DatabaseFactory.Config(x =>
            {
                x.UsingDatabase(() => new NPoco.Database("conndb", NPoco.DatabaseType.SQLite));
                x.WithFluentConfig(fluentConfig);
            });
        }
    }

}