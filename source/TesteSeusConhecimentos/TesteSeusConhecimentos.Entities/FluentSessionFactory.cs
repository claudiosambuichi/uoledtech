using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace TesteSeusConhecimentos.Entities
{
    public class FluentSessionFactory
    {

        private static ISessionFactory session;
        private static string connectionString = @"Database=TesteConhecimento; Server=.\SQLEXPRESS; User Id=testeSQL; Password=teste42";

        public static ISessionFactory criarSession()
        {
            
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);

            var configMapUser = Fluently.Configure().Database(configDB)
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.UserMap>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.EnterpriseMap>())
                .Mappings(c => c.FluentMappings.AddFromAssemblyOf<Mapping.UserEnterpriseMap>());
            
            session = configMapUser.BuildSessionFactory();

            return session;

        }


        public static ISession abrirSession()
        {
            return criarSession().OpenSession();
        }

    }
}
