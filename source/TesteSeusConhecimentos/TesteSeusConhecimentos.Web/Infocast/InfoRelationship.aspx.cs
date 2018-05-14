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
        private IRelationshipRepository RelationshipRepository;

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
            this.RelationshipRepository = new RelationshipRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var enterpriseRepository = new EnterpriseRepository();
                var enterprises = enterpriseRepository.GetAll();

                var userRepository = new UserRepository();
                var users = userRepository.GetAll();

                UsuarioDropDownList.DataSource = users;
                UsuarioDropDownList.DataValueField = "IdUser";
                UsuarioDropDownList.DataTextField = "Name";
                UsuarioDropDownList.DataBind();

                EmpresaDropDownList.DataSource = enterprises;
                EmpresaDropDownList.DataValueField = "IdEnterprise";
                EmpresaDropDownList.DataTextField = "Name";
                EmpresaDropDownList.DataBind();

                if (enterprises.Count > 0 && users.Count > 0)
                {
                    btnSalvar.Enabled = true;
                }

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
            Relationship relationship = this.RelationshipRepository.GetById(idRelationship);

            if (relationship != null)
            {
                formStatus.InnerText = "Editar Relacionamentos";
                UsuarioDropDownList.SelectedValue = UsuarioDropDownList.Items.FindByText(relationship.UserName).Value;
                EmpresaDropDownList.SelectedValue = EmpresaDropDownList.Items.FindByText(relationship.EnterpriseName).Value;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Relationship Relationship = new Relationship(idRelationship, UsuarioDropDownList.SelectedItem.Text, EmpresaDropDownList.SelectedItem.Text);
            RelationshipRepository.Save(Relationship);

            Response.Redirect("~/Infocast/Relationships.aspx");
        }
    }
}