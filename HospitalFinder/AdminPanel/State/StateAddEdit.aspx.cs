using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Page.RouteData.Values["StateID"] != null)
            {
                #region Load Data in Edit Mode
                LoadControls(Convert.ToInt32(Page.RouteData.Values["StateID"]));
                lblPageHeader.Text = "State Edit";
                btnAdd.Text = "Update";
                #endregion Load Data in Edit Mode
            }
            else
            {
                lblPageHeader.Text = "State Add";
            }
        }
    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 StateID)
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
                    objCmd.CommandText = "PR_LOC_State_SelectByPK";
                    objCmd.Parameters.AddWithValue("@StateID", StateID);
                    #endregion Prepare Command

                    #region ReadData and Set Controls
                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["StateName"].Equals(DBNull.Value))
                            {
                                txtStateName.Text = objSDR["StateName"].ToString();
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlString strStateName = SqlString.Null;
        #endregion Local Variables

        #region Server Side Validation

        string strError = "";
        if (txtStateName.Text.Trim() == "")
            strError += " - Enter State Name<br />";

        if (strError.Trim() != "")
        {
            lblMessage.Text = strError;
            return;
        }

        #endregion Server Side Validation

        #region Read Data
        if (txtStateName.Text.Trim() != "")
            strStateName = txtStateName.Text.Trim();
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
                    objCmd.Parameters.AddWithValue("@StateName", strStateName);


                    if (Page.RouteData.Values["StateID"] == null)
                    {
                        objCmd.CommandText = "PR_LOC_State_Insert";
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    }
                    else
                    {
                        objCmd.CommandText = "PR_LOC_State_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@StateID", Page.RouteData.Values["StateID"].ToString());
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
                    if (Page.RouteData.Values["StateID"] == null)
                    {
                        lblMessage.Text = "Data Inserted Successfully.....";
                        txtStateName.Text = "";
                        txtStateName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/State/StateList.aspx");
                    }

                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion Button : Save
}