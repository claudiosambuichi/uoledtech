using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationshipMap : ClassMap<Relationship>
    {
        public RelationshipMap()
        {
            Id(c => c.IdRelationship);
            Map(c => c.UserId);
            Map(c => c.EnterpriseId);
            Table("TesteSeusConhecimentos.RelationshipData");
        }
    }
}
