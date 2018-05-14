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
    public partial class Relationships : System.Web.UI.Page
    {
        private IRelationshipsRepository relationshipsRepository;

        public Relationships()
        {
            this.relationshipsRepository = new RelationshipsRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateGridRelationShips();
            }
        }

        protected void grdUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int IdRelationShips = Convert.ToInt32(e.CommandArgument);

            switch (e.CommandName)
            {
                case ("Remove"):
                    relationshipsRepository.Delete(IdRelationShips);
                    UpdateGridRelationShips();
                    break;
                case ("Edit"):
                    Response.Redirect("~/Infocast/InfoRelationships.aspx?id=" + IdRelationShips, true) ;
                    break;
            }
           
        }

        private void UpdateGridRelationShips()
        {
            var relationShips = relationshipsRepository.GetAll();
            grdUsers.DataSource = relationShips.ToList();
            grdUsers.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Infocast/InfoRelationships.aspx");
        }
    }
}