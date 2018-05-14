using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface IRelationshipsRepository
    {

        IList<CommandRelationships> GetAll();
        Relationships GetById(int id);
        void Delete(int id);
        void Save(Relationships relationships);
    }
}
