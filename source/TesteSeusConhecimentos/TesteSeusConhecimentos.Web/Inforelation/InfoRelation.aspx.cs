using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Inforelation
{
    public partial class InfoRelation : System.Web.UI.Page
    {
        private IRelationRepository relationRepository;
        private IUserRepository userRepository;
        private IEnterpriseRepository enterpriseRepository;

        private int idRelation
        {
            set { ViewState["idRelation"] = value; }
            get
            {
                if (ViewState["idRelation"] != null)
                    return Convert.ToInt32(ViewState["idRelation"]);

                return 0;
            }
        }

        public InfoRelation()
        {
            this.relationRepository = new RelationRepository();
            this.userRepository = new UserRepository();
            this.enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Preencher dropdown de empresas e usuários
                ddlUserName.DataSource = userRepository.GetAll().ToList();
                ddlUserName.DataTextField = "Name";
                ddlUserName.DataValueField = "IdUser";
                ddlUserName.DataBind();

                ddlEnterpriseName.DataSource = enterpriseRepository.GetAll().ToList();
                ddlEnterpriseName.DataTextField = "Name";
                ddlEnterpriseName.DataValueField = "IdEnterprise";
                ddlEnterpriseName.DataBind();

                SetViewStateUser();
                UpdateForm();
            }
        }

        private void SetViewStateUser()
        {
            if (Request.QueryString["id"] != null)
                idRelation = Convert.ToInt32(Request.QueryString["id"]);
            else
                idRelation = 0;
        }

        private void UpdateForm()
        {
            Entities.Relation relation = this.relationRepository.GetById(idRelation);

            if (relation != null)
            {
                formStatus.InnerText = "Editar Relacionamento";
                ddlUserName.SelectedValue = relation.IdUser.ToString();
                ddlEnterpriseName.SelectedValue = relation.IdEnterprise.ToString();
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Entities.Relation relation = new Entities.Relation(idRelation, Convert.ToInt32(ddlEnterpriseName.SelectedValue), Convert.ToInt32(ddlUserName.SelectedValue));
            relationRepository.Save(relation);

            Response.Redirect("~/Inforelation/Relation.aspx");
        }
    }
}