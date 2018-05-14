using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface IEnterpriseRepository
    {
        IList<Enterprise> GetAll();
        Enterprise GetById(int id);
        void Delete(int id);
        /// <summary>
        /// Cria ou altera as informações da Empresa
        /// </summary>
        /// <param name="empresa"></param>
        void Save(Enterprise enterprise);
    }
}
