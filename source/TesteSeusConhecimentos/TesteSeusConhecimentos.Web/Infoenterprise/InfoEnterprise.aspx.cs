using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infoenterprise
{
    public partial class InfoEnterprise : System.Web.UI.Page
    {
        private IEnterpriseRepository enterpriseRepository;

        private int idEnterprise
        {
            set { ViewState["idEnterprise"] = value; }
            get
            {
                if (ViewState["idEnterprise"] != null)
                    return Convert.ToInt32(ViewState["idEnterprise"]);

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
                idEnterprise = Convert.ToInt32(Request.QueryString["id"]);
            else
                idEnterprise = 0;
        }

        private void UpdateForm()
        {
            Entities.Enterprise enterprise = this.enterpriseRepository.GetById(idEnterprise);

            if (enterprise != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtName.Text = enterprise.Name;
                txtStreetAdress.Text = enterprise.StreetAdress;
                txtState.Text = enterprise.State;
                txtCity.Text = enterprise.City;
                txtCorporateActivity.Text = enterprise.CorporateActivity;
                txtZipCode.Text = enterprise.ZipCode;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidZipCode(txtZipCode.Text))
            {
                Entities.Enterprise enterprise = new Entities.Enterprise(idEnterprise, txtName.Text, txtStreetAdress.Text, txtCity.Text, txtState.Text, txtZipCode.Text, txtCorporateActivity.Text);
                enterpriseRepository.Save(enterprise);

                Response.Redirect("~/Infoenterprise/Enterprise.aspx");
            }
            else
                ClientScript.RegisterStartupScript(Page.GetType(), "msg", "<script>alert('CEP: Por favor, informar 8 números');</script>");

        }

        public bool ValidZipCode(string value)
        {
            if (value.Length < 7 || value.Length > 8)
                return false;

            if (!value.All(char.IsDigit))
                return false;

            return true;
        }
    }
}