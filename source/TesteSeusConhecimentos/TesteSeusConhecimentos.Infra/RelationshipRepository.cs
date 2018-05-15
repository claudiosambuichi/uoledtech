using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using NHibernate.Linq;

namespace TesteSeusConhecimentos.Infra
{
    public class RelationshipRepository : IRelationshipRepository
    {
        //private static IList<Relationship> Relationships;

        public RelationshipRepository()
        {
        }


        public IList<Relationship> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<Relationship>() select e).ToList();
            }
        }


        public Relationship GetById(int id)
        {

            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Relationship>(id);
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
                        Relationship relationship = session.Get<Relationship>(id);
                        if (relationship != null)
                        {
                            session.Delete(relationship);
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

        public void Save(Relationship relationship)
        {
            if (relationship.IsNew())
                Add(relationship);
            else
                Update(relationship);
        }


        private void Add(Relationship relationship)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(relationship);
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


        private void Update(Relationship relationship)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(relationship);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar relacionamento: " + e.Message);
                    }
                }
            }
        }
    }
}
