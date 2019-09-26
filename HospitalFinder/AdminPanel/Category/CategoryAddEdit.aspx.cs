using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Category_CategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CategoryID"] != null)
            {
                #region Load Data in Edit Mode
                LoadControls(Convert.ToInt32(Request.QueryString["CategoryID"]));
                lblPageHeader.Text = "Category Edit";
                btnAdd.Text = "Update";
                #endregion Load Data in Edit Mode
            }
            else
            {
                lblPageHeader.Text = "Category Add";
            }
        }
    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 CategoryID)
    {
        using (SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            objConn.Open();
            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_HOS_Category_SelectByPK";
                    objCmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                    #endregion Prepare Command

                    #region ReadData and Set Controls
                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["CategoryName"].Equals(DBNull.Value))
                            {
                                txtCategoryName.Text = objSDR["CategoryName"].ToString();
                            }
                        }
                    }

                    #endregion ReadData and Set Controls
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion Load Controls

    #region Button : Save
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strCategoryName = SqlString.Null;
        #endregion Local Variables

        #region Server Side Validation

        string strError = "";
        if (txtCategoryName.Text.Trim() == "")
            strError += " - Enter Category Name<br />";

        if (strError.Trim() != "")
        {
            lblMessage.Text = strError;
            return;
        }

        #endregion Server Side Validation

        #region Read Data
        if (txtCategoryName.Text.Trim() != "")
            strCategoryName = txtCategoryName.Text.Trim();
        #endregion Read Data

        using (SqlConnection objConn = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            objConn.Open();
            using (SqlCommand objCmd = objConn.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.Parameters.AddWithValue("@CategoryName", strCategoryName);
                    

                    if (Request.QueryString["CategoryID"] == null)
                    {
                        objCmd.CommandText = "PR_HOS_Category_Insert";
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    }
                    else
                    {
                        objCmd.CommandText = "PR_HOS_Category_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CategoryID", Request.QueryString["CategoryID"].ToString());
                    }
                    #endregion Prepare Command

                    objCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
                finally
                {
                    if (Request.QueryString["CategoryID"] == null)
                    {
                        lblMessage.Text = "Data Inserted Successfully.....";
                        txtCategoryName.Text = "";
                        txtCategoryName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/Category/CategoryList.aspx");
                    }

                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion Button : Save
}
