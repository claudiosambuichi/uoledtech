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
    public class RelationshipRepository : IRelationshipRepository
    {
        //private static IList<Empresa> Empresas;

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
                        Relationship Relationship = session.Get<Relationship>(id);
                        if (Relationship != null)
                        {
                            session.Delete(Relationship);
                            transacao.Commit();
                        }                       
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao deletar um relacionamento: " + e.Message);
                    }
                }
            }
        }

        public void Save(Relationship Relationship)
        {
            if (Relationship.IsNew())
                Add(Relationship);
            else
                Update(Relationship);
        }

       
        private void Add(Relationship Relationship)
        {
            using (ISession session = FluentSessionFactory.abrirSession()) 
            {
                using (ITransaction transacao = session.BeginTransaction()) 
                {
                    try
                    {
                        session.Save(Relationship);
                        transacao.Commit();
                    }
                    catch (Exception e) 
                    {
                        if(!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao relacionar: "+e.Message);
                    }
                }
            }
        }


        private void Update(Relationship Empresa)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(Empresa);
                        transacao.Commit();
                    }
                    catch (Exception e)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Erro ao atualizar um relacionamento: " + e.Message);
                    }
                }
            }
        }
                       
    }
}
