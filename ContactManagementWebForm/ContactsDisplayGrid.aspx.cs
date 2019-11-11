using BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactManagementWebForm
{
    public partial class ContactsDisplayGrid : System.Web.UI.Page
    {

        #region Private Helper Methods
        private void InitializePage()
        {
            txtSearch.Text = string.Empty;
            FetchContactData();
        }



        private void FetchContactData()
        {
            if (Cache["ContactList"] == null)
            {
                try
                {
                    Contact process = new Contact();
                    var list = process.ShowContactInfoByStartingLetter(txtSearch.Text);
                    this.grid1.DataSource = list;
                    this.grid1.DataBind();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                var list = Cache["ContactList"] as List<Contact>;
                this.grid1.DataSource = list;
                this.grid1.DataBind();
            }
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) InitializePage();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FetchContactData();
        }



        protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grid1.PageIndex = e.NewPageIndex;
            FetchContactData();
        }



        protected void grid1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = this.grid1.DataKeys[e.NewEditIndex].Value.ToString();
            Response.Redirect("UpdateProduct.aspx?id=" + id);
        }



        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            FetchContactData();
        }



        protected void btnCreateView_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateContact.aspx");
        }
    }
}