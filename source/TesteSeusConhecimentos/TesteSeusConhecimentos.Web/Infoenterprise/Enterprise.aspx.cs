using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infoenterprise
{
    public partial class Enterprise : System.Web.UI.Page
    {
        private IEnterpriseRepository enterpriseRepository;

        public Enterprise()
        {
            this.enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridEnterprise();
            }
        }

        protected void grdEnterprise_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEnterprise = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    enterpriseRepository.Delete(idEnterprise);
                    UpdateGridEnterprise();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infoenterprise/InfoEnterprise.aspx?id=" + idEnterprise, true);
                    break;
            }

        }

        private void UpdateGridEnterprise()
        {
            var enterprises = enterpriseRepository.GetAll();
            grdEnterprise.DataSource = enterprises.ToList();
            grdEnterprise.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infoenterprise/InfoEnterprise.aspx");
        }

        public string FormatZipCode(string value)
        {
            return value.Insert(value.Length - 3, "-");
        }
    }
}