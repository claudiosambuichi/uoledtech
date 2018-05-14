using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;

namespace TesteSeusConhecimentos.Entities
{
    public class FluentSessionFactory
    {

        private static ISessionFactory session;
        private static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\msv20\Documents\MEGA\projetos\uoledtech-master\source\TesteSeusConhecimentos\TesteSeusConhecimentos.Web\App_Data\TesteSeusConhecimentos.mdf;Integrated Security=True";

        public static ISessionFactory criarSession()
        {

            if (session != null)
                return session;

            IPersistenceConfigurer configDB = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);

            var configMap = Fluently.Configure().Database(configDB)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.UserMap>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.EnterpriseMap>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.RelationshipMap>());

            session = configMap.BuildSessionFactory();

            return session;

        }


        public static ISession abrirSession()
        {
            return criarSession().OpenSession();
        }

    }
}
