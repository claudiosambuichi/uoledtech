namespace TesteSeusConhecimentos.Entities
{
    public class Relation
    {
        public virtual int IdRelation { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual int IdUser { get; set; }

        public Relation()
        {

        }

        public Relation(int idRelation, int idEnterprise, int idUser)
        {
            this.IdRelation = idRelation;
            this.IdEnterprise = idEnterprise;
            this.IdUser = idUser;
        }

        public virtual bool IsNew()
        {
            return this.IdRelation == 0;
        }
    }
}
