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
    public partial class listaRelacionamentos : System.Web.UI.Page
    {
        private IRelacionamentosRepository relacionamentosRepository;
        private IUserRepository userRepository;
        private IEnterpriseRepository enterpriseRepository;

        public listaRelacionamentos()
        {
            this.relacionamentosRepository = new RelacionamentosRepository();
            this.userRepository = new UserRepository();
            this.enterpriseRepository = new EnterpriseRepository();
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                UpdateGridRelacionamentos();
            }
        }

        protected void grdRelacionamentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdRelacionamentos = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    relacionamentosRepository.Delete(IdRelacionamentos);
                    UpdateGridRelacionamentos();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoRelacionamentos.aspx?id=" + IdRelacionamentos, true);
                    break;
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoRelacionamentos.aspx");
        }

        private void UpdateGridRelacionamentos()
        {
            var rel = relacionamentosRepository.GetAll();

            var user = userRepository.GetAll();

            var enterprise = enterpriseRepository.GetAll();

            var list = (from r in rel
                       join u in user on r.IdUser equals u.IdUser
                       join e in enterprise on r.IdEnterprise equals e.IdEnterprise
                       select new
                       {
                           IdRelacionamentos = r.IdRelacionamentos,
                           IdEnterprise = r.IdEnterprise,
                           IdUser = r.IdUser,
                           Empresa = e.Name,
                           Usuario = u.Name
                       }).OrderByDescending(o => o.IdRelacionamentos);

            grdRelacionamentos.DataSource = list.ToList();
            grdRelacionamentos.DataBind();
        }
    }
}