using System;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Companys : System.Web.UI.Page
    {
        #region Construtor
        private ICompanyRepository companyRepository;

        public Companys()
        {
            this.companyRepository = new CompanyRepository();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridCompany();
            }
        }

        protected void grdCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCompany = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    companyRepository.Delete(idCompany);
                    UpdateGridCompany();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoCompany.aspx?id=" + idCompany, true);
                    break;
            }

        }

        private void UpdateGridCompany()
        {
            var companys = companyRepository.GetAll();
            grdCompany.DataSource = companys.ToList();
            grdCompany.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoCompany.aspx");
        }
    }
}