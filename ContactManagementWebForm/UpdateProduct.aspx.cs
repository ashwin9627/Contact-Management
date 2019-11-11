using BussinessLogic;
using Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContactManagementWebForm
{
    public partial class UpdateProduct : System.Web.UI.Page
    {
            #region private helper methods
            private void InitializePage()
            {

            }
            private void PopulateCategories()
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString;
                string sql = "SELECT ContactId,firstName,lastName,Birthday,Email,WorkNumber,HomeNumber,MobileNumber FROM Categories";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionString);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Categories");
                ddlCategories.DataSource = ds.Tables["Categories"];
                ddlCategories.DataTextField = "CategoryName";
                ddlCategories.DataValueField = "CategoryId";
                ddlCategories.DataBind();

            }
            protected void AssignValuesToTextBoxes(ContactInfo Model)
            {
                txtName.Text = Model.firstName;
                txtPrice.Text = Model.middleName.ToString();
                txtStock.Text = Model.lastName.ToString();
                chkDiscontinued.Text=Model.Birthday.ToString();
                txtEmail.Text = Model.Email;
                txtHomeNumber.Text = Model.HomeNumber;
                txtworkNumber.Text = Model.WorkNumber;
                txtmobileNumber.Text = Model.MobileNumber;

            ddlCategories.SelectedValue = Model.CategoryId.ToString();
            }

            private Contact retriveValuesFromControls()
            {
                ContactInfo model = new ContactInfo();
                model.ProductName = txtName.Text;
                model.UnitPrice = Convert.ToDecimal("0" + txtPrice.Text);
                model.UnitsInStock = Convert.ToInt16("0" + txtStock.Text);
                model.Discontinued = chkDiscontinued.Checked;
                model.CategoryId = Convert.ToInt32("0" + ddlCategories.SelectedValue);
                model.productId = Convert.ToInt32("0" + Request.QueryString["Id"]);
                return model;
            }

            private void LoadProductDetails()
            {
                int productId = Convert.ToInt32("0" + Request.QueryString["id"]);
                if (productId != 0)
                {
                    productProcess process = new productProcess();
                    var item = process.GetProduct(productId);
                    AssignValuesToTextBoxes(item[0]);
                }
            }
            private void SaveProductDetails()
            {
                Product obj = retriveValuesFromControls();
                productProcess process = new productProcess();
                process.UpdateProduct1(obj);
            }

            #endregion

            #region Events
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack) //NOT ISPOSTBACK
                {
                    InitializePage();
                    PopulateCategories();
                    LoadProductDetails();
                }

            }

            protected void btnSave_Click(object sender, EventArgs e)
            {
                SaveProductDetails();
                Cache.Remove("productList");
                //Cache["[productList"] = null;

                Response.Redirect("ProductMaster.aspx");
            }

            protected void btnCancel_Click(object sender, EventArgs e)
            {
                Response.Redirect("ContactDis1Master.aspx");
            }







            #endregion
        }
    }