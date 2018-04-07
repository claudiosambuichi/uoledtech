using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra
{
    public class UserEnterpriseRepository : IUserEnterpriseRepository
    {
        public void Delete(int idUser, int idEnterprise)
        {
            throw new System.NotImplementedException();
        }

        public IList<UserEnterprise> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<UserEnterprise>() select e).ToList();
            }
        }

        public UserEnterprise GetById(int idUser, int idEnterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<UserEnterprise>(new UserEnterprise() {IdEnterprise = idEnterprise, IdUser = idUser });
            }
        }

        public UserEnterprise GetById(int idUserEnterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<UserEnterprise>(idUserEnterprise);
            }
        }

        public void Save(UserEnterprise userEnterprise)
        {
            if (userEnterprise.IsNew())
                Add(userEnterprise);
            else
                Update(userEnterprise);
        }


        private void Add(UserEnterprise userEnterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(userEnterprise);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir usuario em empresa: " + e.Message);
                    }
                }
            }
        }


        private void Update(UserEnterprise userEnterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(userEnterprise);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar usuário em empresa: " + e.Message);
                    }
                }
            }
        }
    }
}
