using System;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Relationships : System.Web.UI.Page
    {
        private IRelationshipRepository relationshipRepository;
        private IUserRepository userRepository;
        private ICompanyRepository companyRepository;

        public Relationships()
        {
            this.relationshipRepository = new RelationshipRepository();
            this.userRepository = new UserRepository();
            this.companyRepository = new CompanyRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridRelationships();
            }
        }

        protected void grdRelationships_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idRelationship = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    relationshipRepository.Delete(idRelationship);
                    UpdateGridRelationships();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoRelationship.aspx?id=" + idRelationship, true);
                    break;
            }

        }

        private void UpdateGridRelationships()
        {
            var relationships = relationshipRepository.GetAll();
            
            //Dever existe uma forma melhor de fazer com certeza o relacioamento, mas não conheço muito bem o 
            //Nhibernate, mas acredito que der sim para fazer o mapeado dos objetos em relaciomento.
            var user = userRepository.GetAll();
            var company = companyRepository.GetAll();

            foreach (var relationship in relationships)
            {
                relationship.Company = company.FirstOrDefault(x => x.IdCompany == relationship.CompanyId).Name;
                relationship.User = user.FirstOrDefault(x => x.IdUser == relationship.UserId).Name;
            }

            grdRelationships.DataSource = relationships.ToList();
            grdRelationships.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoRelationship.aspx");
        }
    }
}
