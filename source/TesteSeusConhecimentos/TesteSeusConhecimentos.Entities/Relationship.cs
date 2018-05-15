using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Relationship
    {
        public virtual int IdRelationship { get; set; }
        public virtual int EnterpriseId { get; set; }
        public virtual int UserId { get; set; }


        public Relationship()
        {

        }

        public Relationship(int idRelationship, int enterpriseId, int userId)
        {
            this.IdRelationship = idRelationship;
            this.EnterpriseId = enterpriseId;
            this.UserId = userId;
        }

        public virtual bool IsNew()
        {
            return this.IdRelationship == 0;
        }
    }
}
