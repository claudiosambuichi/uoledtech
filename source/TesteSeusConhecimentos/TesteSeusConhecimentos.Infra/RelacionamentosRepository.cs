using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using NHibernate.Linq;

namespace TesteSeusConhecimentos.Infra
{
    public class RelacionamentosRepository : IRelacionamentosRepository
    {
        //private static IList<Relacionamentos> relacionamentos;

        public RelacionamentosRepository()
        {
        }


        public IList<Relacionamentos> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<Relacionamentos>() select e).ToList();
            }
        }


        public Relacionamentos GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Relacionamentos>(id);
            }
        }


        public void Delete(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        Relacionamentos relacionamentos = session.Get<Relacionamentos>(id);
                        if (relacionamentos != null)
                        {
                            session.Delete(relacionamentos);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar usuário: " + e.Message);
                    }
                }
            }
        }

        public void Save(Relacionamentos relacionamentos)
        {
            if (relacionamentos.IsNew())
                Add(relacionamentos);
            else
                Update(relacionamentos);
        }


        private void Add(Relacionamentos relacionamentos)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(relacionamentos);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir usuário: " + e.Message);
                    }
                }
            }
        }


        private void Update(Relacionamentos relacionamentos)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(relacionamentos);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar usuário: " + e.Message);
                    }
                }
            }
        }
    }
}
