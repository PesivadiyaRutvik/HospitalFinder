using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientPanel_HospitalDetails : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Page.RouteData.Values["HospitalID"] != null)
            {
                #region Load Data in Edit Mode
                LoadControls(Convert.ToInt32(Page.RouteData.Values["HospitalID"]));
                #endregion Load Data in Edit Mode
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
                            if (!objSDR["HospitalName"].Equals(DBNull.Value))
                            {
                                txtHospitalName.InnerText = objSDR["HospitalName"].ToString();
                            }
                            if (!objSDR["Address"].Equals(DBNull.Value))
                            {
                                txtAddress.InnerText = objSDR["Address"].ToString();
                            }
                            if (!objSDR["MobileNumber"].Equals(DBNull.Value))
                            {
                                txtMobileNumber.InnerText = objSDR["MobileNumber"].ToString();
                            }
                            if (!objSDR["TelephoneNumber"].Equals(DBNull.Value))
                            {
                                txtTelephoneNumber.InnerText = objSDR["TelephoneNumber"].ToString();
                            }
                            if (!objSDR["EmergencyNumber"].Equals(DBNull.Value))
                            {
                                txtEmergencyNumber.InnerText = objSDR["EmergencyNumber"].ToString();
                            }
                            if (!objSDR["AmbulancePhoneNumber"].Equals(DBNull.Value))
                            {
                                txtAmbulancePhoneNumber.InnerText = objSDR["AmbulancePhoneNumber"].ToString();
                            }
                            if (!objSDR["Website"].Equals(DBNull.Value))
                            {
                                txtWebsite.InnerText = objSDR["Website"].ToString();
                            }
                            if (!objSDR["EmailID"].Equals(DBNull.Value))
                            {
                                txtEmailID.InnerText = objSDR["EmailID"].ToString();
                            }
                            if (!objSDR["Fax"].Equals(DBNull.Value))
                            {
                                txtFax.InnerText = objSDR["Fax"].ToString();
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

}