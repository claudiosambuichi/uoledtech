using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationshipsMap: ClassMap<Relationships>
    {
        public RelationshipsMap()
        {            
            Id(c => c.IdRelationships);
            Map(c => c.IdEnterprise);
            Map(c => c.IdUser);
            Map(c => c.DateRelationsships);
            Table("TesteSeusConhecimentos.RelationshipsData");
        }
       
    }
}
