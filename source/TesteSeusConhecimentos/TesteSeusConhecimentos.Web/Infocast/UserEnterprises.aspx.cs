using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Entities;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Infocast
{
    public partial class UserEnterprises : System.Web.UI.Page
    {
        IUserEnterpriseRepository _userEnterpriseRepository;
        IUserRepository _userRepository;
        IEnterpriseRepository _enterpriseRepository;


        public UserEnterprises()
        {
            _userEnterpriseRepository = new UserEnterpriseRepository();
            _userRepository = new UserRepository();
            _enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //empresas
                var enterprises = _enterpriseRepository.GetAll();
                CarregarDDL(enterprises, DropDownEnterprises, "IdEnterprise", "CorporateActivity");

                //usuarios
                var users = _userRepository.GetAll();
                CarregarDDL(users, DropDownUsers, "IdUser", "Name");
            }
        }

        public static void CarregarDDL<TEntity>(IList<TEntity> list, DropDownList ddl, string value, string text)
        {
            if (list.Count > 0)
            {
                ddl.DataSource = list;
                ddl.DataTextField = text;
                ddl.DataValueField = value;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("Selecione", "0"));
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UserEnterprise userEnterprise = new UserEnterprise()
            {
                IdUser = Convert.ToInt32(DropDownUsers.SelectedValue),
                IdEnterprise = Convert.ToInt32(DropDownEnterprises.SelectedValue),
            };
            _userEnterpriseRepository.Save(userEnterprise);

            Response.Redirect("~/");
        }

      
    }
}