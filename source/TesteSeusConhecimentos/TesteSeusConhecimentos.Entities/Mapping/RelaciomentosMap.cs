using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Entities.Mapping
{
    public class RelaciomentosMap: ClassMap<Relacionamentos>
    {
        public RelaciomentosMap()
        {
            Id(c => c.IdRelacionamentos);
            Map(c => c.IdEnterprise);
            Map(c => c.IdUser);            
            Table("TesteSeusConhecimentos.Relacionamentos");
        }
    }
}
