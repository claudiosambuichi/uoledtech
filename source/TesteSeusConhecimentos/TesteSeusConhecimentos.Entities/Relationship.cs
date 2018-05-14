using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Relationship
    {
        public virtual int IdRelationship { get; set; }
        public virtual string UserName { get; set; }
        public virtual string EnterpriseName { get; set; }

        public Relationship()
        {

        }

        public Relationship(int idRelationship, string userName, string enterpriseName)
        {
            this.IdRelationship = idRelationship;
            this.UserName = userName;
            this.EnterpriseName = enterpriseName;
        }

        public virtual bool IsNew()
        {
            return this.IdRelationship == 0;
        }
    }
}
