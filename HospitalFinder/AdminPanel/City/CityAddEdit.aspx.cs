using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Page.RouteData.Values["CityID"] != null)
            {
                #region Load Data in Edit Mode
                LoadControls(Convert.ToInt32(Page.RouteData.Values["CityID"]));
                lblPageHeader.Text = "City Edit";
                btnAdd.Text = "Update";
                #endregion Load Data in Edit Mode
            }
            else
            {
                lblPageHeader.Text = "City Add";
            }
        }
    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 CityID)
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
                    objCmd.CommandText = "PR_LOC_City_SelectByPK";
                    objCmd.Parameters.AddWithValue("@CityID", CityID);
                    #endregion Prepare Command

                    #region ReadData and Set Controls
                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["StateID"].Equals(DBNull.Value))
                            {
                                ddlState.SelectedValue = objSDR["StateID"].ToString();
                            }
                            if (!objSDR["CityName"].Equals(DBNull.Value))
                            {
                                txtCityName.Text = objSDR["CityName"].ToString();
                            }
                            if (!objSDR["PinCode"].Equals(DBNull.Value))
                            {
                                txtPinCode.Text = objSDR["PinCode"].ToString();
                            }
                            if (!objSDR["STDCode"].Equals(DBNull.Value))
                            {
                                txtSTDCode.Text = objSDR["STDCode"].ToString();
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
        SqlString strCityName = SqlString.Null;
        SqlString strPinCode = SqlString.Null;
        SqlString strSTDCode = SqlString.Null;
        #endregion Local Variables

        #region Server Side Validation

        string strError = "";
        if (txtCityName.Text.Trim() == "")
            strError += " - Enter City Name<br />";

        if (txtPinCode.Text.Trim() == "")
            strError += " - Enter PinCode <br />";

        if (txtSTDCode.Text.Trim() == "")
            strError += " - Enter STDCode <br />";

        if (strError.Trim() != "")
        {
            lblMessage.Text = strError;
            return;
        }

        #endregion Server Side Validation

        #region Read Data
        if (txtCityName.Text.Trim() != "")
            strCityName = txtCityName.Text.Trim();

        if (txtPinCode.Text.Trim() != "")
            strPinCode = txtPinCode.Text.Trim();

        if (txtSTDCode.Text.Trim() != "")
            strSTDCode = txtSTDCode.Text.Trim();

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
                    objCmd.Parameters.AddWithValue("@StateID", ddlState.SelectedValue);
                    objCmd.Parameters.AddWithValue("@CityName", strCityName);
                    objCmd.Parameters.AddWithValue("@PinCode", strPinCode);
                    objCmd.Parameters.AddWithValue("@STDCode", strSTDCode);

                    if (Page.RouteData.Values["CityID"] == null)
                    {
                        objCmd.CommandText = "PR_LOC_City_Insert";
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    }
                    else
                    {
                        objCmd.CommandText = "PR_LOC_City_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@CityID", Page.RouteData.Values["CityID"].ToString());
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
                    if (Page.RouteData.Values["CityID"] == null)
                    {
                        lblMessage.Text = "Data Inserted Successfully.....";
                        txtCityName.Text = "";
                        txtPinCode.Text = "";
                        txtSTDCode.Text = "";
                        txtCityName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/City/CityList.aspx");
                    }

                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion Button : Save

    #region FillDropDownList
    private void FillDropDownList()
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            objConnection.Open();

            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    #region Prepare Command;
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_LOC_State_SelectDropDownList";
                    #endregion Prepare Command
                    SqlDataReader objSDRState = objCmd.ExecuteReader();
                    ddlState.DataSource = objSDRState;
                    ddlState.DataValueField = "StateID";
                    ddlState.DataTextField = "StateName";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, new ListItem("Select State", "-1"));

                }
                catch (Exception ex)
                {
                    lblMessage.Text = ex.Message.ToString();
                }
                finally
                {
                    objConnection.Close();
                }
            }
        }
    }
    #endregion FillDropDownList
}