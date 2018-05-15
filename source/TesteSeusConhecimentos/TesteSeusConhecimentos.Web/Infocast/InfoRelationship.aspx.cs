using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class InfoRelationship : System.Web.UI.Page
    {
        private IRelationshipRepository relationshipRepository;
        private IEnterpriseRepository enterpriseRepository;
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
            this.enterpriseRepository = new EnterpriseRepository();
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
            List<Enterprise> enterprises = this.enterpriseRepository.GetAll().ToList();
            List<User> users = this.userRepository.GetAll().ToList();

            if (enterprises != null && users != null)
            {
                formStatus.InnerText = "Editar Relacionamento";

                ddlEmpresa.DataSource = enterprises;
                ddlEmpresa.DataTextField = "StreetAddress";
                ddlEmpresa.DataValueField = "IdEnterprise";
                ddlEmpresa.DataBind();

                ddlUsuario.DataSource = users;
                ddlUsuario.DataTextField = "Name";
                ddlUsuario.DataValueField = "IdUser";
                ddlUsuario.DataBind();
            }
        }

        protected void btnRelacionar_Click(object sender, EventArgs e)
        {
            Relationship relationship = new Relationship(idRelationship, Convert.ToInt32(ddlEmpresa.SelectedItem.Value), Convert.ToInt32(ddlUsuario.SelectedItem.Value));
            relationshipRepository.Save(relationship);
            
            Response.Redirect("~/Infocast/Relationships.aspx");
        }
    }
}