using FluentNHibernate.Mapping;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationshipMap: ClassMap<Relationship>
    {
        public RelationshipMap()
        {
            Id(c => c.IdRelationship);
            Map(c => c.UserId);
            Map(c => c.CompanyId);
            Table("TesteSeusConhecimentos.RelationshipData");
        }
    }
}
