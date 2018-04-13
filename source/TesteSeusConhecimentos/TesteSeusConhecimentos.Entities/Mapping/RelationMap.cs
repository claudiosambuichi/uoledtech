using FluentNHibernate.Mapping;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationMap : ClassMap<Relation>
    {
        public RelationMap()
        {
            Id(c => c.IdRelation);
            Map(c => c.IdEnterprise);
            Map(c => c.IdUser);
            Table("TesteSeusConhecimentos.RelationData");
        }
    }
}
