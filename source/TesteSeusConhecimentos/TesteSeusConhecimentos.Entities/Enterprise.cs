namespace TesteSeusConhecimentos.Entities
{
    public class Enterprise
    {
        public virtual int IdEnterprise { get; set; }
        public virtual string StreetAdress { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual string CorporateActivity { get; set; }

        public Enterprise()
        {

        }

        public Enterprise(int id, string streetAdress, string city, string state, string zipCode, string corporateActivity)
        {
            IdEnterprise = id;
            StreetAdress = streetAdress;
            City = city;
            State = state;
            ZipCode = zipCode;
            CorporateActivity = corporateActivity;
        }

        public virtual bool IsNew()
        {
            return this.IdEnterprise == 0;
        }
    }
}
