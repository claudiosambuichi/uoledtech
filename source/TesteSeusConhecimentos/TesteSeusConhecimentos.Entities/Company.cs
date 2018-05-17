namespace TesteSeusConhecimentos.Entities
{
    public class Company
    {
        public Company()
        { }

        public Company(int idCompany, string name, string streetAdress, string city, string state, string zipCode, string companyActivity)
        {
            Name = name;
            IdCompany = idCompany;
            StreetAdress = streetAdress;
            City = city;
            State = state;
            ZipCode = zipCode;
            CompanyActivity = companyActivity;
        }

        public virtual int IdCompany { get; set; }
        public virtual string Name { get; set; }
        public virtual string StreetAdress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string CompanyActivity { get; set; }



        public virtual bool IsNew()
            => this.IdCompany == 0;
    }
}
