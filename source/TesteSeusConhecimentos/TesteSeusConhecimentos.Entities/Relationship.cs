namespace TesteSeusConhecimentos.Entities
{
    public class Relationship
    {
        public virtual int IdRelationship { get; set; }
        public virtual int CompanyId { get; set; }
        public virtual int UserId { get; set; }

        public virtual string Company { get; set; }
        public virtual string User { get; set; }


        public Relationship()
        { }

        public Relationship(int idRelationship, int companyId, int userId)
        {
            this.IdRelationship = idRelationship;
            this.CompanyId = companyId;
            this.UserId = userId;
        }

        public virtual bool IsNew() => IdRelationship == 0;        
    }
}
