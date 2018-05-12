﻿using System;
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
    public partial class InfoRelationships : System.Web.UI.Page
    {
        private IRelationshipsRepository relationshipsRepository;

        private int IdRelationships
        {
            set { ViewState["IdRelationships"] = value; }
            get
            {
                if (ViewState["IdRelationships"] != null)
                    return Convert.ToInt32(ViewState["IdRelationships"]);

                return 0;
            }
        }

        public InfoRelationships()
        {
            this.relationshipsRepository = new RelationshipsRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetViewStateEnterprise();
                UpdateForm();
            }

            LoadDropDownEnterprise();

            LoadDropDownUser();

        }

        private void LoadDropDownEnterprise()
        {

        }

        private void LoadDropDownUser()
        {

        }


        private void SetViewStateEnterprise()
        {
            if (Request.QueryString["id"] != null)
                IdRelationships = Convert.ToInt32(Request.QueryString["id"]);
            else
                IdRelationships = 0;
        }

        private void UpdateForm()
        {
            TesteSeusConhecimentos.Entities.Relationships relationShips = this.relationshipsRepository.GetById(IdRelationships);

            if (relationShips != null)
            {
                //formStatus.InnerText = "Editar Empresa";
                //txtStreetAdress.Text = enterprise.StreetAdress;
                //txtCity.Text = enterprise.City;
                //txtState.Text = enterprise.State;
                //txtZipCode.Text = enterprise.ZipCode;
                //txtCorporateActivit.Text = enterprise.CorporateActivit;

            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {

            TesteSeusConhecimentos.Entities.Relationships enterprise = new TesteSeusConhecimentos.Entities.Relationships();
            relationshipsRepository.Save(enterprise);            
            
            Response.Redirect("~/Infocast/Enterprise.aspx");
        }
    }
}