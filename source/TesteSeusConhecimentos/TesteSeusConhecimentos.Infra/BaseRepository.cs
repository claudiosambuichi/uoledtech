using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Infra
{
    public abstract class BaseRepository<TEntity>: IBaseRepository<TEntity> where TEntity: class, new()
    {
        public IList<TEntity> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<TEntity>() select e).ToList();
            }
        }

        public TEntity GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<TEntity>(id);
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
                        Company company = session.Get<Company>(id);
                        if (company != null)
                        {
                            session.Delete(company);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar empresa: " + e.Message);
                    }
                }
            }
        }

        public void Save(TEntity model)
        {
            if ((bool)model.GetType().GetMethod("IsNew").Invoke(model, null))
                Add(model);
            else
                Update(model);
        }

        private void Add(TEntity model)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(model);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir empresa: " + e.Message);
                    }
                }
            }
        }

        private void Update(TEntity model)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(model);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar empresa: " + e.Message);
                    }
                }
            }
        }
    }
}
