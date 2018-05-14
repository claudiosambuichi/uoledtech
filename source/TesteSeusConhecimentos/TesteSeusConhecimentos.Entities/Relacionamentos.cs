using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TesteSeusConhecimentos.Entities
{
    public class Relacionamentos
    {
        public virtual int IdRelacionamentos { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual int IdUser { get; set; }

        public Relacionamentos()
        {

        }

        public Relacionamentos(int idRelacionamentos, int idEnterprise, int idUser)
        {
            this.IdRelacionamentos = idRelacionamentos;
            this.IdEnterprise = idEnterprise;
            this.IdUser = idUser;
        }

        public virtual bool IsNew()
        {
            return this.IdRelacionamentos == 0;
        }
    }
}
