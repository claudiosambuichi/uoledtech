using FluentNHibernate.Mapping;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class UserEnterpriseMap : ClassMap<UserEnterprise>
    {
        public UserEnterpriseMap()
        {
            Id(p => p.IdUserEnterprise);
            Map(c => c.IdEnterprise);
            Map(c => c.IdUser);

            HasOne(p => p.Enterprise);
            HasOne(p => p.User);

            Table("TesteSeusConhecimentos.UserEnterpriseData");
        }
       
    }
}
