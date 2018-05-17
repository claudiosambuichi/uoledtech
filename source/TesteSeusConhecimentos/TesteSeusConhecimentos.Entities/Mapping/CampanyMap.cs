using FluentNHibernate.Mapping;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class CompanyMap: ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(x => x.IdCompany);
            Map(c => c.Name);
            Map(x => x.StreetAdress);
            Map(x => x.City);
            Map(x => x.State);
            Map(x => x.ZipCode);
            Map(x => x.CompanyActivity);
            Table("TesteSeusConhecimentos.CompanyData");
        }
    }
}
