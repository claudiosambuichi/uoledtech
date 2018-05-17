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
            Company company = companyRepository.GetById(idCompany);

            if (company != null)
            {
                formStatus.InnerText = "Editar Empresa";
                txtName.Text = company.Name;
                txtStreetAddress.Text = company.StreetAdress;
                txtCity.Text = company.City;
                txtState.Text = company.State;
                txtZipCode.Text = company.ZipCode;
                txtCompanyActivity.Text = company.CompanyActivity;
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Company Company = new Company(idCompany, txtName.Text, txtStreetAddress.Text, txtCity.Text, 
                txtState.Text, txtZipCode.Text, txtCompanyActivity.Text);
            companyRepository.Save(Company);

            Response.Redirect("~/Infocast/Companys.aspx");
        }
    }
}