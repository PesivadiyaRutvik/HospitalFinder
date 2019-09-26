using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Hospital_HospitalAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Page.RouteData.Values["HospitalID"] != null)
            {
                #region Load Data in Edit Mode
                LoadControls(Convert.ToInt32(Page.RouteData.Values["HospitalID"]));
                lblPageHeader.Text = "Hospital Edit";
                btnAdd.Text = "Update";
                #endregion Load Data in Edit Mode
            }
            else
            {
                lblPageHeader.Text = "Hospital Add";
            }
        }
    }
    #endregion Load Event

    #region Load Controls
    private void LoadControls(Int32 HospitalID)
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
                    objCmd.CommandText = "PR_HOS_Hospital_SelectByPK";
                    objCmd.Parameters.AddWithValue("@HospitalID", HospitalID);
                    #endregion Prepare Command

                    #region ReadData and Set Controls
                    SqlDataReader objSDR = objCmd.ExecuteReader();

                    if (objSDR.HasRows)
                    {
                        while (objSDR.Read())
                        {
                            if (!objSDR["CityID"].Equals(DBNull.Value))
                            {
                                ddlCity.SelectedValue = objSDR["CityID"].ToString();
                            }
                            if (!objSDR["CategoryID"].Equals(DBNull.Value))
                            {
                                ddlCategory.SelectedValue = objSDR["CategoryID"].ToString();
                            }
                            if (!objSDR["CategoryTypeID"].Equals(DBNull.Value))
                            {
                                ddlCategoryType.SelectedValue = objSDR["CategoryTypeID"].ToString();
                            }
                            if (!objSDR["HospitalName"].Equals(DBNull.Value))
                            {
                                txtHospitalName.Text = objSDR["HospitalName"].ToString();
                            }
                            if (!objSDR["Address"].Equals(DBNull.Value))
                            {
                                txtAddress.Text = objSDR["Address"].ToString();
                            }
                            if (!objSDR["MobileNumber"].Equals(DBNull.Value))
                            {
                                txtMobileNumber.Text = objSDR["MobileNumber"].ToString();
                            }
                            if (!objSDR["TelephoneNumber"].Equals(DBNull.Value))
                            {
                                txtTelePhoneNumber.Text = objSDR["TelephoneNumber"].ToString();
                            }
                            if (!objSDR["Fax"].Equals(DBNull.Value))
                            {
                                txtFax.Text = objSDR["Fax"].ToString();
                            }
                            if (!objSDR["Website"].Equals(DBNull.Value))
                            {
                                txtWebsite.Text = objSDR["Website"].ToString();
                            }
                            if (!objSDR["EmailID"].Equals(DBNull.Value))
                            {
                                txtEmailAddress.Text = objSDR["EmailID"].ToString();
                            }
                            if (!objSDR["AmbulancePhoneNumber"].Equals(DBNull.Value))
                            {
                                txtAmbulancePhoneNumber.Text = objSDR["AmbulancePhoneNumber"].ToString();
                            }
                            if (!objSDR["EmergencyNumber"].Equals(DBNull.Value))
                            {
                                txtEmergencyNumber.Text = objSDR["EmergencyNumber"].ToString();
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
        SqlString strHospitalName = SqlString.Null;
        SqlString strAddress = SqlString.Null;
        SqlString strMobileNumber = SqlString.Null;
        SqlString strTelephoneNumber = SqlString.Null;
        SqlString strFax = SqlString.Null;
        SqlString strWebsite = SqlString.Null;
        SqlString strEmailID = SqlString.Null;
        SqlString strAmbulancePhoneNumber = SqlString.Null;
        SqlString strEmergencyNumber = SqlString.Null;
        #endregion Local Variables

        #region Server Side Validation

        string strError = "";
        if (txtHospitalName.Text.Trim() == "")
            strError += " - Enter Hospital Name<br />";

        if (txtAddress.Text.Trim() == "")
            strError += " - Enter Address <br />";

        if (strError.Trim() != "")
        {
            lblMessage.Text += strError;
            return;
        }

        #endregion Server Side Validation

        #region Read Data
        if (txtHospitalName.Text.Trim() != "")
            strHospitalName = txtHospitalName.Text.Trim();

        if (txtAddress.Text.Trim() != "")
            strAddress = txtAddress.Text.Trim();

        if (txtMobileNumber.Text.Trim() != "")
            strMobileNumber = txtMobileNumber.Text.Trim();

        if (txtTelePhoneNumber.Text.Trim() != "")
            strTelephoneNumber = txtTelePhoneNumber.Text.Trim();

        if (txtFax.Text.Trim() != "")
            strFax = txtFax.Text.Trim();

        if (txtWebsite.Text.Trim() != "")
            strWebsite = txtWebsite.Text.Trim();

        if (txtEmailAddress.Text.Trim() != "")
            strEmailID = txtEmailAddress.Text.Trim();

        if (txtAmbulancePhoneNumber.Text.Trim() != "")
            strAmbulancePhoneNumber = txtAmbulancePhoneNumber.Text.Trim();

        if (txtEmergencyNumber.Text.Trim() != "")
            strEmergencyNumber = txtEmergencyNumber.Text.Trim();


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
                    objCmd.Parameters.AddWithValue("@CityID", ddlCity.SelectedValue);
                    objCmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedValue);
                    objCmd.Parameters.AddWithValue("@CategoryTypeID", ddlCategoryType.SelectedValue);
                    objCmd.Parameters.AddWithValue("@HospitalName", strHospitalName);
                    objCmd.Parameters.AddWithValue("@Address", strAddress);
                    objCmd.Parameters.AddWithValue("@MobileNumber", strMobileNumber);
                    objCmd.Parameters.AddWithValue("@TelephoneNumber", strTelephoneNumber);
                    objCmd.Parameters.AddWithValue("@Fax", strFax);
                    objCmd.Parameters.AddWithValue("@Website", strWebsite);
                    objCmd.Parameters.AddWithValue("@EmailID", strEmailID);
                    objCmd.Parameters.AddWithValue("@AmbulancePhoneNumber", strAmbulancePhoneNumber);
                    objCmd.Parameters.AddWithValue("@EmergencyNumber", strEmergencyNumber);

                    if (Page.RouteData.Values["HospitalID"] == null)
                    {
                        objCmd.CommandText = "PR_HOS_Hospital_Insert";
                        objCmd.Parameters.AddWithValue("@CreationDate", DateTime.Now);
                    }
                    else
                    {
                        objCmd.CommandText = "PR_HOS_Hospital_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@HospitalID", Page.RouteData.Values["HospitalID"].ToString());
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
                    if (Page.RouteData.Values["HospitalID"] == null)
                    {
                        lblMessage.Text = "Data Inserted Successfully.....";
                        txtHospitalName.Text = "";
                        txtAddress.Text = "";
                        txtMobileNumber.Text = "";
                        txtTelePhoneNumber.Text = "";
                        txtFax.Text = "";
                        txtAmbulancePhoneNumber.Text = "";
                        txtEmergencyNumber.Text = "";
                        txtWebsite.Text = "";
                        txtEmailAddress.Text = "";
                        txtHospitalName.Focus();
                    }
                    else
                    {
                        Response.Redirect("~/AdminPanel/Hospital/HospitalList.aspx");
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

            //For City

            SqlCommand objCmd1 = new SqlCommand();
            objCmd1.Connection = objConnection;
            objCmd1.CommandType = CommandType.StoredProcedure;

            objCmd1.CommandText = "PR_LOC_City_SelectDropDownList";
            SqlDataReader objSDRCity = objCmd1.ExecuteReader();
            ddlCity.DataSource = objSDRCity;
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "CityID";
            ddlCity.DataBind();
            ddlCity.Items.Insert(0, new ListItem("Select City", "-1"));
            objSDRCity.Close();

            //For Category

            SqlCommand objCmd2 = new SqlCommand();
            objCmd2.Connection = objConnection;
            objCmd2.CommandType = CommandType.StoredProcedure;

            objCmd2.CommandText = "PR_HOS_Category_SelectDropDownList";
            SqlDataReader objSDRCategory = objCmd2.ExecuteReader();
            ddlCategory.DataSource = objSDRCategory;
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "-1"));
            objSDRCategory.Close();

            //For CategoryType 

            SqlCommand objCmd3 = new SqlCommand();
            objCmd3.Connection = objConnection;
            objCmd3.CommandType = CommandType.StoredProcedure;

            objCmd3.CommandText = "PR_HOS_CategoryType_SelectDropDownList";
            SqlDataReader objSDRCategoryType = objCmd3.ExecuteReader();
            ddlCategoryType.DataSource = objSDRCategoryType;
            ddlCategoryType.DataValueField = "CategoryTypeID";
            ddlCategoryType.DataTextField = "CategoryType";
            ddlCategoryType.DataBind();
            ddlCategoryType.Items.Insert(0, new ListItem("Select Category Type", "-1"));
            objSDRCategoryType.Close();

            objConnection.Close();
        }
    }
    #endregion FillDropDownList
}