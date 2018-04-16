using System;
using System.Linq;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class Enterprises : System.Web.UI.Page
    {
        private IEnterpriseRepository _enterpriseRepository;

        public Enterprises()
        {
            this._enterpriseRepository = new EnterpriseRepository();
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
                    _enterpriseRepository.Delete(idEnterprise);
                    UpdateGridEnterprise();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoEnterprise.aspx?id=" + idEnterprise, true);
                    break;
            }
           
        }

        private void UpdateGridEnterprise()
        {
            var enterprises = _enterpriseRepository.GetAll();
            grdEnterprise.DataSource = enterprises.ToList();
            grdEnterprise.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoEnterprise.aspx");
        }
    }
}