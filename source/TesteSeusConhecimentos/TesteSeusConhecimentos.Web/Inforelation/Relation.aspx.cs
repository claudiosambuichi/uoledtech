using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteSeusConhecimentos.Domain;
using TesteSeusConhecimentos.Infra;

namespace TesteSeusConhecimentos.Web.Inforelation
{
    public partial class Relation : System.Web.UI.Page
    {
        private IRelationRepository relationRepository;
        private IUserRepository userRepository;
        private IEnterpriseRepository enterpriseRepository;

        public Relation()
        {
            this.relationRepository = new RelationRepository();
            this.userRepository = new UserRepository();
            this.enterpriseRepository = new EnterpriseRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridRelation();
            }
        }

        protected void grdRelations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idRelation = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    relationRepository.Delete(idRelation);
                    UpdateGridRelation();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Inforelation/InfoRelation.aspx?id=" + idRelation, true);
                    break;
            }

        }

        private void UpdateGridRelation()
        {
            //Com tempo, mudar para retornar a consulta já com os dados relacionados
            var relations = relationRepository.GetAll();
            var users = userRepository.GetAll();
            var enterprises = enterpriseRepository.GetAll();

            var retorno = (from rel in relations
                           join us in users on rel.IdUser equals us.IdUser
                           join en in enterprises on rel.IdEnterprise equals en.IdEnterprise
                           select new
                           {
                               IdRelation = rel.IdRelation,
                               EnterpriseName = en.Name,
                               UserName = $"{us.Name} {us.LastName}" 
                           }).ToList();

            grdRelation.DataSource = retorno.ToList();
            grdRelation.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Inforelation/InfoRelation.aspx");
        }
    }
}