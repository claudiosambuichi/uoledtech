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
    public class RelationshipsRepository : IRelationshipsRepository
    {
        public IList<Entities.Relationships> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return (from e in session.Query<Relationships>() select e).ToList();
            }
        }

        public Relationships GetById(int id)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Relationships>(id);
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
                        Relationships relationships = session.Get<Relationships>(id);
                        if (relationships != null)
                        {
                            session.Delete(relationships);
                            transacao.Commit();
                        }
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar Relacionamento: " + e.Message);
                    }
                }
            }
        }

        public void Save(Relationships relationships)
        {
            if (relationships.IsNew())
                Add(relationships);
            else
                Update(relationships);
        }

        private void Add(Relationships relationships)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(relationships);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao inserir relacionamentos: " + e.Message);
                    }
                }
            }
        }


        private void Update(Relationships relationships)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(relationships);
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
