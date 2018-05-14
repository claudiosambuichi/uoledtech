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
    public partial class InfoEnterprise : System.Web.UI.Page
    {
        private IEnterpriseRepository enterpriseRepository;

        private int IdEnterprise
        {
            set { ViewState["IdEnterprise"] = value; }
            get
            {
                if (ViewState["IdEnterprise"] != null)
                    return Convert.ToInt32(ViewState["IdEnterprise"]);

                return 0;
            }
        }

        public InfoEnterprise()
        {
            this.enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetViewStateEnterprise();
                UpdateForm();
            }
        }

        private void SetViewStateEnterprise()
        {
            if (Request.QueryString["id"] != null)
                IdEnterprise = Convert.ToInt32(Request.QueryString["id"]);
            else
                IdEnterprise = 0;
        }

        private void UpdateForm()
        {
            TesteSeusConhecimentos.Entities.Enterprise enterprise = this.enterpriseRepository.GetById(IdEnterprise);

            if (enterprise != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtName.Text = enterprise.Name;
                txtStreetAdress.Text = enterprise.StreetAdress;
                txtCity.Text = enterprise.City;
                txtState.Text = enterprise.State;
                txtZipCode.Text = enterprise.ZipCode;
                txtCorporateActivit.Text = enterprise.CorporateActivit;

            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            TesteSeusConhecimentos.Entities.Enterprise enterprise = new TesteSeusConhecimentos.Entities.Enterprise(IdEnterprise, txtName.Text, txtStreetAdress.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtCorporateActivit.Text);
            enterpriseRepository.Save(enterprise);            
            
            Response.Redirect("~/Infocast/Enterprise.aspx");
        }
    }
}