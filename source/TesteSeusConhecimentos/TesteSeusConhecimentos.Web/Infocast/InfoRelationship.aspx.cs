using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class InfoRelationship : System.Web.UI.Page
    {
        private IRelationshipRepository relationshipRepository;
        private ICompanyRepository enterpriseRepository;
        private IUserRepository userRepository;

        private int idRelationship
        {
            set { ViewState["idRelationship"] = value; }
            get
            {
                if (ViewState["idRelationship"] != null)
                    return Convert.ToInt32(ViewState["idRelationship"]);

                return 0;
            }
        }

        public InfoRelationship()
        {
            this.relationshipRepository = new RelationshipRepository();
            this.enterpriseRepository = new CompanyRepository();
            this.userRepository = new UserRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetViewStateRelationship();
                UpdateForm();
            }
        }

        private void SetViewStateRelationship()
        {
            if (Request.QueryString["id"] != null)
                idRelationship = Convert.ToInt32(Request.QueryString["id"]);
            else
                idRelationship = 0;
        }

        private void UpdateForm()
        {
            IList<Company> company = this.enterpriseRepository.GetAll();
            IList<User> users = this.userRepository.GetAll().ToList();

            if (company != null && users != null)
            {
                formStatus.InnerText = "Editar Relacionamento";

                #region Company
                    ddlCompany.DataSource = company;
                    ddlCompany.DataTextField = "StreetAdress";
                    ddlCompany.DataValueField = "IdCompany";
                    ddlCompany.DataBind();
                #endregion
                #region User
                    ddlUser.DataSource = users;
                    ddlUser.DataTextField = "Name";
                    ddlUser.DataValueField = "IdUser";
                    ddlUser.DataBind();
                #endregion
            }
        }

        protected void btnRelacionar_Click(object sender, EventArgs e)
        {
            Relationship relationship = new Relationship(idRelationship, Convert.ToInt32(ddlCompany.SelectedItem.Value), Convert.ToInt32(ddlUser.SelectedItem.Value));
            relationshipRepository.Save(relationship);
            Response.Redirect("~/Infocast/Relationships.aspx");
        }
    }
}