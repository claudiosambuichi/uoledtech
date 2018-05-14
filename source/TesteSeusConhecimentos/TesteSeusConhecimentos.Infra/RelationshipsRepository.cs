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
        public IList<CommandRelationships> GetAll()
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                 return (from rs in session.Query<Relationships>()
                         join u in session.Query<User>() on rs.IdUser equals u.IdUser
                         join e in session.Query<Enterprise>() on rs.IdEnterprise equals e.IdEnterprise
                         select new CommandRelationships() { 
                                 Id = rs.IdRelationships,
                                 Enterprise = e.Name,
                                 User = u.Name      
                         }).ToList();
                        
            }
        }

        public Relationships GetById(int id)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                return session.Get<Relationships>(id);                
            }
        }

        public bool IsExistsRelationships(int idUser, int idEnterprise)
        {
            using (ISession session = FluentSessionFactory.abrirSession())
            {
                var relationships = session
                    .Query<Relationships>()
                    .Where(x => x.IdUser == idUser &&
                            x.IdEnterprise == idEnterprise                                           
                          ).FirstOrDefault();

                if(relationships == null)
                    return false;
                else
                    return true;
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
            {
                if (!IsExistsRelationships(relationships.IdUser, relationships.IdEnterprise))
                    Add(relationships);
                else
                    throw new Exception("Este relacionamento já existe na base de dados!");
                
            }
            else
            {
                if (!IsExistsRelationships(relationships.IdUser, relationships.IdEnterprise))
                    Update(relationships);
                else
                    throw new Exception("Este relacionamento já existe na base de dados!");
                
            }
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
