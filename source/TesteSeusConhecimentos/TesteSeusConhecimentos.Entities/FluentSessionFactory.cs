using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace TesteSeusConhecimentos.Entities
{
    public class FluentSessionFactory
    {

        private static ISessionFactory session;
        private static string connectionString = @"Initial Catalog=TesteSeusConhecimentos;Data Source=DESKTOP-RBFLC37\SQLEXPRESS;Integrated Security=SSPI;";
            //@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|TesteSeusConhecimentos.mdf;Integrated Security=True";

        public static ISessionFactory criarSession()
        {
            
            if (session != null)
                return session;

            IPersistenceConfigurer configDB = MsSqlConfiguration.MsSql2012.ConnectionString(connectionString);

            var configMap = Fluently.Configure().Database(configDB)
                .Mappings(c =>
                {
                    c.FluentMappings.AddFromAssemblyOf<Mapping.UserMap>();
                    c.FluentMappings.AddFromAssemblyOf<Mapping.CompanyMap>();
                    c.FluentMappings.AddFromAssemblyOf<Mapping.RelationshipMap>();
                });
            session = configMap.BuildSessionFactory();

            return session;

        }


        public static ISession abrirSession()
        {
            return criarSession().OpenSession();
        }

    }
}
