using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_CategoryType_CategoryTypeAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CategoryTypeID"] != null)
            {
                #region Load Data in Edit Mode
                LoadControls(Convert.ToInt32(Request.QueryString["CategoryTypeID"]));
                lblPageHeader.Text = "Category Type Edit";
                btnAdd.Text = "Update";
                #endregion Load Data in Edit Mode
            }
            else
            {
                lblPageHeader.Text = "Category Type Add";
            }
        }
    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 CategoryTypeID)
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
                    objCmd.CommandText = "PR_HOS_CategoryType_SelectByPK";
                    objCmd.Parameters.AddWithValue("@CategoryTypeID", CategoryTypeID);
                    #endregion Prepare Command

                    #region ReadData and Set Controls
                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["CategoryType"].Equals(DBNull.Value))
                            {
                                txtCategoryType.Text = objSDR["CategoryType"].ToString();
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
        SqlString strCategoryType = SqlString.Null;
        #endregion Local Variables

        #region Server Side Validation

        string strError = "";
        if (txtCategoryType.Text.Trim() == "")
            strError += " - Enter Category Type <br />";

        if (strError.Trim() != "")
        {
            lblMessage.Text = strError;
            return;
        }

        #endregion Server Side Validation

        #region Read Data
        if (txtCategoryType.Text.Trim() != "")
            strCategoryType = txtCategoryType.Text.Trim();
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
                    objCmd.Parameters.AddWithValue("@CategoryType", strCategoryType);


                    if (Request.QueryString["CategoryTypeID"] == null)
                    {
                        objCmd.CommandText = "PR_HOS_CategoryType_Insert";
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    }
                    else
                    {
                        objCmd.CommandText = "PR_HOS_CategoryType_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CategoryTypeID", Request.QueryString["CategoryTypeID"].ToString());
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
                    if (Request.QueryString["CategoryTypeID"] == null)
                    {
                        lblMessage.Text = "Data Inserted Successfully.....";
                        txtCategoryType.Text = "";
                        txtCategoryType.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/CategoryType/CategoryTypeList.aspx");
                    }

                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion Button : Save
}