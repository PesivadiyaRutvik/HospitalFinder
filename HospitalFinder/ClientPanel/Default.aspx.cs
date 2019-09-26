using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientPanel_Default : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillStateDropDownList();
            FillCityDropDownList();
            FillCategoryDropDownList();
            FillCategoryTypeDropDownList();
        }
    }
    #endregion Load Event

    #region FillGridView
    private void FillGridView()
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
                    objCmd.CommandText = "PR_HOS_Hospital_SelectAll";
                    #endregion Prepare Command

                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    DataTable dtState = new DataTable();
                    dtState.Load(objSDR);

                    gvHospitalListByStateName.DataSource = dtState;
                    gvHospitalListByStateName.DataBind();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }
            }
        }
    }
    #endregion FillGridView

    #region Button : Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGridViewOnButtonClick();
    }
    #endregion Button : Search

    #region Button : Clear
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtsearch.Text = "";
        ddlState.SelectedValue = "-1";
        ddlCity.SelectedValue = "-1";
        ddlCategory.SelectedValue = "-1";
        ddlCategoryType.SelectedValue = "-1";
    }
    #endregion Button : Clear

    #region Button : SecondSearch
    protected void btnSecondSearch_Click(object sender, EventArgs e)
    {
        if (ddlState.SelectedValue != "-1")
        {
            FillGridViewOnSecondButtonClick();
        }
        else
        {
            lblMsg.Text = "Select Any Drop Down";
        }
    }
    #endregion Button : SecondSearch

    #region FillGridViewOnButtonClick
    private void FillGridViewOnButtonClick()
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
                    objCmd.CommandText = "PR_HOS_Hospital_Search";

                    if (txtsearch.Text != "")
                    {
                        objCmd.Parameters.AddWithValue("@HospitalName", txtsearch.Text.Trim());
                    }
                    if (ddlState.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlState.SelectedValue));
                    }
                    if (ddlCity.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@CityID", Convert.ToInt32(ddlCity.SelectedValue));
                    }
                    if (ddlCategory.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(ddlCategory.SelectedValue));
                    }
                    if (ddlCategoryType.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@CategoryTypeID", Convert.ToInt32(ddlCategoryType.SelectedValue));
                    }
                    #endregion Prepare Command

                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    DataTable dtState = new DataTable();
                    dtState.Load(objSDR);

                    gvHospitalListByStateName.DataSource = dtState;
                    gvHospitalListByStateName.DataBind();
                    pnlSearch.Visible = true;
                }
                catch (Exception ex)
                {
                    lblMsg.Text += ex.Message.ToString();
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }
            }
        }
    }
    #endregion FillGridViewOnButtonClick

    #region FillGridViewOnSecondButtonClick
    private void FillGridViewOnSecondButtonClick()
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
                    objCmd.CommandText = "PR_HOS_Hospital_Search";
                    if (txtSecondSearch.Text != "")
                    {
                        objCmd.Parameters.AddWithValue("@HospitalName", txtSecondSearch.Text.Trim());
                    }
                    if (ddlState.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@StateID", Convert.ToInt32(ddlState.SelectedValue));
                    }
                    if (ddlCity.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@CityID", Convert.ToInt32(ddlCity.SelectedValue));
                    }
                    if (ddlCategory.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@CategoryID", Convert.ToInt32(ddlCategory.SelectedValue));
                    }
                    if (ddlCategoryType.SelectedValue != "-1")
                    {
                        objCmd.Parameters.AddWithValue("@CategoryTypeID", Convert.ToInt32(ddlCategoryType.SelectedValue));
                    }

                    #endregion Prepare Command

                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    DataTable dtState = new DataTable();
                    dtState.Load(objSDR);

                    gvHospitalListByStateName.DataSource = dtState;
                    gvHospitalListByStateName.DataBind();
                }
                catch (Exception ex)
                {
                    lblMsg.Text += ex.Message.ToString();
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                    {
                        objConn.Close();
                    }
                }
            }
        }
    }
    #endregion FillGridViewOnSecondButtonClick

    #region FillStateDropDownList
    private void FillStateDropDownList()
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            objConnection.Open();

            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_LOC_State_SelectDropDownList";
                    #endregion Prepare Command
                    SqlDataReader objSDRState = objCmd.ExecuteReader();
                    ddlState.DataSource = objSDRState;
                    ddlState.DataTextField = "StateName";
                    ddlState.DataValueField = "StateID";
                    ddlState.DataBind();
                    ddlState.Items.Insert(0, new ListItem("-----Select State-----", "-1"));

                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
                finally
                {
                    objConnection.Close();
                }
            }
        }
    }
    #endregion FillStateDropDownList

    #region FillCityDropDownList
    private void FillCityDropDownList()
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            objConnection.Open();

            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_LOC_City_SelectDropDownList";
                    #endregion Prepare Command
                    SqlDataReader objSDRCity = objCmd.ExecuteReader();
                    ddlCity.DataSource = objSDRCity;
                    ddlCity.DataTextField = "CityName";
                    ddlCity.DataValueField = "CityID";
                    ddlCity.DataBind();
                    ddlCity.Items.Insert(0, new ListItem("-----Select City-----", "-1"));
                }

                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
                finally
                {
                    objConnection.Close();
                }
            }
        }
    }
    #endregion FillCityDropDownList

    #region FillCategoryDropDownList
    private void FillCategoryDropDownList()
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            objConnection.Open();
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_HOS_Category_SelectDropDownList";
                    #endregion Prepare Command
                    SqlDataReader objSDRCategory = objCmd.ExecuteReader();
                    ddlCategory.DataSource = objSDRCategory;
                    ddlCategory.DataTextField = "CategoryName";
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-----Select Category-----", "-1"));

                }

                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
                finally
                {
                    objConnection.Close();
                }
            }
        }
    }
    #endregion FillCategoryDropDownList

    #region FillCategoryTypeDropDownList
    private void FillCategoryTypeDropDownList()
    {
        using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
        {
            objConnection.Open();
            using (SqlCommand objCmd = objConnection.CreateCommand())
            {
                try
                {
                    #region Prepare Command
                    objCmd.CommandType = CommandType.StoredProcedure;
                    objCmd.CommandText = "PR_HOS_CategoryType_SelectDropDownList";
                    #endregion Prepare Command
                    SqlDataReader objSDRCategoryType = objCmd.ExecuteReader();
                    ddlCategoryType.DataSource = objSDRCategoryType;
                    ddlCategoryType.DataTextField = "CategoryType";
                    ddlCategoryType.DataValueField = "CategoryTypeID";
                    ddlCategoryType.DataBind();
                    ddlCategoryType.Items.Insert(0, new ListItem("-----Select Hospital Type-----", "-1"));

                }

                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
                finally
                {
                    objConnection.Close();
                }
            }
        }
    }
    #endregion FillCategoryTypeDropDownList

    #region State Index Changed
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        #region State Index
        if (ddlState.SelectedIndex != -1)
        {
            int StateID = Convert.ToInt32(ddlState.SelectedValue);

            using (SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                objConnection.Open();

                using (SqlCommand objCmd = objConnection.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_LOC_City_SelectDropDownListByStateID";
                        objCmd.Parameters.AddWithValue("@StateID",StateID);
                        #endregion Prepare Command
                        SqlDataReader objSDRCity = objCmd.ExecuteReader();
                        ddlCity.DataSource = objSDRCity;
                        ddlCity.DataTextField = "CityName";
                        ddlCity.DataValueField = "CityID";
                        ddlCity.DataBind();
                        ddlCity.Items.Insert(0, new ListItem("-----Select City-----", "-1"));
                    }

                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.Message.ToString();
                    }
                    finally
                    {
                        objConnection.Close();
                    }
                }
            }
        }
        #endregion State Index
    }
    #endregion State Index Changed
}