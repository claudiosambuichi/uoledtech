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
    public partial class InfoRelationships : System.Web.UI.Page
    {
        private IRelationshipsRepository relationshipsRepository;
        private IUserRepository userRepository;
        private IEnterpriseRepository enterpriseRepository;

        private int IdRelationships
        {
            set { ViewState["IdRelationships"] = value; }
            get
            {
                if (ViewState["IdRelationships"] != null)
                    return Convert.ToInt32(ViewState["IdRelationships"]);

                return 0;
            }
        }

        public InfoRelationships()
        {
            this.relationshipsRepository = new RelationshipsRepository();
            this.userRepository = new UserRepository();
            this.enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetViewStateEnterprise();
                UpdateForm();
                LoadDropDownEnterprise();
                LoadDropDownUser();
            }

        }

        private void LoadDropDownEnterprise()
        {
            ddlEnterprise.AppendDataBoundItems = true; 
            
            var enterprises = enterpriseRepository.GetAll();                 
            ddlEnterprise.DataSource = enterprises.ToList();
            ddlEnterprise.DataTextField = "Name";
            ddlEnterprise.DataValueField = "IdEnterprise";
            ddlEnterprise.DataBind();
        }

        private void LoadDropDownUser()
        {
            ddlUser.AppendDataBoundItems = true;  

            var users = userRepository.GetAll();                     
            ddlUser.DataSource = users.ToList();
            ddlUser.DataTextField = "Name";
            ddlUser.DataValueField = "IdUser";
            ddlUser.DataBind();

        }


        private void SetViewStateEnterprise()
        {
            if (Request.QueryString["id"] != null)
                IdRelationships = Convert.ToInt32(Request.QueryString["id"]);
            else
                IdRelationships = 0;
        }

        private void UpdateForm()
        {
            TesteSeusConhecimentos.Entities.Relationships relationShips  = this.relationshipsRepository.GetById(IdRelationships);

            if (relationShips != null)
            {
                formStatus.InnerText = "Editar Empresa";
                ddlEnterprise.DataValueField = relationShips.IdEnterprise.ToString();
                ddlUser.DataValueField = relationShips.IdUser.ToString();
          
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
       

            TesteSeusConhecimentos.Entities.Relationships enterprise =
                new TesteSeusConhecimentos.Entities.Relationships(IdRelationships, Convert.ToInt32( ddlEnterprise.SelectedValue), Convert.ToInt32(ddlUser.SelectedValue), DateTime.Now);

            relationshipsRepository.Save(enterprise);            
            
            Response.Redirect("~/Infocast/Relationships.aspx");
        }
    }
}