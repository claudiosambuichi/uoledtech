using System.Collections.Generic;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface ICompanyRepository
    {
        IList<Company> GetAll();
        Company GetById(int id);
        void Delete(int id);
        /// <summary>
        /// Cria ou altera as informações da empresa
        /// </summary>
        /// <param name="user"></param>
        void Save(Company user);
    }
}
