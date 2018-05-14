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
        private IEnterpriseRepository EnterpriseRepository;

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
            this.EnterpriseRepository = new EnterpriseRepository();
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
            Enterprise enterprise = this.EnterpriseRepository.GetById(idEnterprise);

            if (enterprise != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtNome.Text = enterprise.Name;
                txtEndereco.Text = enterprise.StreetAdress;
                txtCidade.Text = enterprise.City;
                txtEstado.Text = enterprise.State;
                txtCep.Text = enterprise.ZipCode;
                txtAtividadesEmpresa.Text = enterprise.CorporateActivity;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Enterprise enterprise = new Enterprise(idEnterprise, txtNome.Text, txtEndereco.Text, txtCidade.Text, txtEstado.Text, txtCep.Text, txtAtividadesEmpresa.Text);
            EnterpriseRepository.Save(enterprise);

            Response.Redirect("~/Infocast/Enterprisies.aspx");
        }
    }
}