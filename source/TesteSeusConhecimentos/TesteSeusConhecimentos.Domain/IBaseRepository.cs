using System.Collections.Generic;

namespace TesteSeusConhecimentos.Domain
{
    public interface IBaseRepository<TEntity> where TEntity: class, new()
    {
        IList<TEntity> GetAll();
        TEntity GetById(int id);
        void Delete(int id);
        /// <summary>
        /// Cria ou altera as informações 
        /// </summary>
        /// <param name="model"></param>
        void Save(TEntity model);
    }
}
