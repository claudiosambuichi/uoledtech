using FluentNHibernate.Mapping;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class CampanyMap: ClassMap<Company>
    {
        public CampanyMap()
        {
            Id(x => x.IdCompany);
            Map(x => x.Name);
            Map(x => x.CNPJ);
            Table("TesteSeusConhecimentos.CampanyData");
        }
    }
}
