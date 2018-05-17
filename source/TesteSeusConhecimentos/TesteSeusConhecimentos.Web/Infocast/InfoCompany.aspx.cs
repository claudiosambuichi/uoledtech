using System;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;
using TesteSeusConhecimentos.Entities;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class InfoCompany : System.Web.UI.Page
    {
        private ICompanyRepository companyRepository;

        private int idCompany
        {
            set { ViewState["idCompany"] = value; }
            get
            {
                if (ViewState["idCompany"] != null)
                    return Convert.ToInt32(ViewState["idCompany"]);

                return 0;
            }
        }

        public InfoCompany()
        {
            this.companyRepository = new CompanyRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetViewStateCompany();
                UpdateForm();
            }
        }

        private void SetViewStateCompany()
        {
            if (Request.QueryString["id"] != null)
                idCompany = Convert.ToInt32(Request.QueryString["id"]);
            else
                idCompany = 0;
        }

        private void UpdateForm()
        {
            Company Company = companyRepository.GetById(idCompany);

            if (Company != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtName.Text = Company.Name;
                txtCNPJ.Text = Company.CNPJ;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Company Company = new Company(idCompany, txtName.Text, txtCNPJ.Text);
            companyRepository.Save(Company);

            Response.Redirect("~/Infocast/Company.aspx");
        }
    }
}