using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Enterprisies : System.Web.UI.Page
    {
        private IEnterpriseRepository enterpriseRepository;

        public Enterprisies()
        {
            this.enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridEnterprisies();
            }
        }

        protected void grdEnterprisies_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idEnterprise = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    enterpriseRepository.Delete(idEnterprise);
                    UpdateGridEnterprisies();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoEnterprise.aspx?id=" + idEnterprise, true);
                    break;
            }
           
        }

        private void UpdateGridEnterprisies()
        {
            var enterprises = enterpriseRepository.GetAll();
            grdEnterprisies.DataSource = enterprises.ToList();
            grdEnterprisies.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoEnterprise.aspx");
        }
    }
}