namespace TesteSeusConhecimentos.Entities
{
    public class Company
    {
        public Company(int idCompany, string name, string cNPJ)
        {
            IdCompany = idCompany;
            Name = name;
            CNPJ = cNPJ;
        }

        public Company()
        { }

        public virtual int IdCompany { get; set; }
        public virtual string Name { get; set; }
        public virtual string CNPJ { get; set; }

        public virtual bool IsNew()
            => this.IdCompany == 0;
    }
}
