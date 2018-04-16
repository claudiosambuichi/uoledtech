using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Domain
{
    public interface IUserEnterpriseRepository
    {
        IList<UserEnterprise> GetAll();
        UserEnterprise GetById(int idUser, int idEnterprise);
        UserEnterprise GetById(int idUserEnterprise);
        void Delete(int idUser, int idEnterprise);

        /// <summary>
        /// Cria ou altera as informações do usuário
        /// </summary>
        /// <param name="user"></param>
        void Save(UserEnterprise userEnterprise);
    }
}
