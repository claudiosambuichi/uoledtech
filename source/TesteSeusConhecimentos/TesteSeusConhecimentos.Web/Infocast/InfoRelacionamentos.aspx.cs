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
    public partial class InfoRelacionamentos : System.Web.UI.Page
    {
 

        private IUserRepository userRepository;
        private IEnterpriseRepository enterpriseRepository;
        private IRelacionamentosRepository relacionamentoRepository;


        public InfoRelacionamentos()
        {
            this.userRepository = new UserRepository();
            this.enterpriseRepository = new EnterpriseRepository();
            this.relacionamentoRepository = new RelacionamentosRepository();

        }

        private int IdRelacionamentos
        {
            set { ViewState["IdRelacionamentos"] = value; }
            get
            {
                if (ViewState["IdRelacionamentos"] != null)
                    return Convert.ToInt32(ViewState["IdRelacionamentos"]);

                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                carregaDllEmpresas();
                carregaDllUsuarios();

                SetViewStateUser();
                UpdateForm();
            }

            
        }

        private void SetViewStateUser()
        {
            if (Request.QueryString["id"] != null)
                IdRelacionamentos = Convert.ToInt32(Request.QueryString["id"]);
            else
                IdRelacionamentos = 0;
        }

        private void UpdateForm()
        {
            Relacionamentos relacionamentos = this.relacionamentoRepository.GetById(IdRelacionamentos);

            if (relacionamentos != null)
            {
                formStatus.InnerText = "Editar Relacionamentos";

                var users = userRepository.GetAll();
                ddlUsuario.DataSource = users.ToList();
                ddlUsuario.DataValueField = "IdUser";
                ddlUsuario.DataTextField = "Name";
                ddlUsuario.DataBind();

                ddlUsuario.SelectedValue = relacionamentos.IdUser.ToString();

                var enterprises = enterpriseRepository.GetAll();
                ddlEmpresa.DataSource = enterprises.ToList();
                ddlEmpresa.DataValueField = "IdEnterprise";
                ddlEmpresa.DataTextField = "Name";
                ddlEmpresa.DataBind();

                ddlEmpresa.SelectedValue = relacionamentos.IdEnterprise.ToString();

            }
        }

        private void carregaDllUsuarios()
        {
            var users = userRepository.GetAll();
            ddlUsuario.DataSource = users.ToList();
            ddlUsuario.DataValueField = "IdUser";
            ddlUsuario.DataTextField = "Name";
            ddlUsuario.DataBind();

            ddlUsuario.Items.Insert(0, new ListItem("Selecione", "0"));           

        }

        private void carregaDllEmpresas()
        {
            var enterprises = enterpriseRepository.GetAll();
            ddlEmpresa.DataSource = enterprises.ToList();
            ddlEmpresa.DataValueField = "IdEnterprise";
            ddlEmpresa.DataTextField = "Name";
            ddlEmpresa.DataBind();
            ddlEmpresa.Items.Insert(0, new ListItem("Selecione", "0"));
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            Relacionamentos relacionamentos = new Relacionamentos(IdRelacionamentos, Convert.ToInt32(ddlEmpresa.SelectedValue), Convert.ToInt32(ddlUsuario.SelectedValue));

            if (relacionamentos.IdEnterprise == 0)
            {
                Response.Redirect("~/Infocast/InfoRelacionamentos.aspx");
            }

            if (relacionamentos.IdUser == 0)
            {
                Response.Redirect("~/Infocast/InfoRelacionamentos.aspx");
            }
            relacionamentoRepository.Save(relacionamentos);

            Response.Redirect("~/Infocast/listaRelacionamentos.aspx");
        }
    }
}