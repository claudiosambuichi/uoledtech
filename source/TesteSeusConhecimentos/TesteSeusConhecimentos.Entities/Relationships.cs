using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Relationships
    {
        public virtual int IdRelationships { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual int IdUser { get; set; }
        public virtual DateTime DateRelationsships { get; set; }

        public Relationships()
        {
        }

        public Relationships(int idRelationships, int idEnterprise, int idUser, DateTime dateRelationsships)
        {
            this.IdRelationships = IdRelationships;
            this.IdEnterprise = idEnterprise;
            this.IdUser = IdUser;
            this.DateRelationsships = dateRelationsships;
        }

        public virtual bool IsNew()
        {
            return this.IdRelationships == 0;
        }

    }
}
