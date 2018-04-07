namespace TesteSeusConhecimentos.Entities
{
    public class UserEnterprise
    {

        public virtual int IdUserEnterprise { get; set; }
        public virtual int IdEnterprise { get; set; }
        public virtual int IdUser { get; set; }

        public virtual Enterprise Enterprise { get; set; }
        public virtual User User { get; set; }

        public UserEnterprise()
        {

        }

        public UserEnterprise(int idUserEnterprise, int idEnterprise, int idUser)
        {
            IdUserEnterprise = idUserEnterprise;
            IdEnterprise = idEnterprise;
            IdUser = idUser;
        }

        public virtual bool IsNew()
        {
            return IdUserEnterprise == 0;
        }
    }
}
