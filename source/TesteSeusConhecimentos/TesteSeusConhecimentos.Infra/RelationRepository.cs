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
    public class RelationRepository : IRelationRepository
    {
        public RelationRepository()
        {
        }

        public IList<Relation> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<Relation>() select e).ToList();
            }
        }

        public Relation GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Relation>(id);
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
                        Relation relation = session.Get<Relation>(id);
                        if (relation != null)
                        {
                            session.Delete(relation);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar relacionamento: " + e.Message);
                    }
                }
            }
        }

        public void Save(Relation relation)
        {
            if (relation.IsNew())
                Add(relation);
            else
                Update(relation);
        }


        private void Add(Relation relation)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(relation);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir relacionamento: " + e.Message);
                    }
                }
            }
        }


        private void Update(Relation relation)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(relation);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar o relacionamento: " + e.Message);
                    }
                }
            }
        }
    }
}
