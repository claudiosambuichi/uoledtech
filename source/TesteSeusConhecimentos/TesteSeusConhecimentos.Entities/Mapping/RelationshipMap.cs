using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelationshipMap : ClassMap<Relationship>
    {


        public RelationshipMap()
        {
            // não sei como trazer o nome do usuário se eu gravar o id do usuário e idempresa, por isso gravei o nome do usuário e nome da empresa
            Id(c => c.IdRelationship);
            Map(c => c.UserName);
            Map(c => c.EnterpriseName);
            Table("TesteSeusConhecimentos.RelationshipData");
        }
    }
}
