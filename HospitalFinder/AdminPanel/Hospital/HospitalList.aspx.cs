using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Hospital_HospitalList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillHospitalGridView();
        }
    }
    #endregion Load Event

    #region GridView

    #region FillGridView
    private void FillHospitalGridView()
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
                    DataTable dtHospital = new DataTable();
                    dtHospital.Load(objSDR);

                    gvHospitalList.DataSource = dtHospital;
                    gvHospitalList.DataBind();
                }
                catch (Exception ex)
                {
                    lblMsg.Text = ex.Message.ToString();
                }
                finally
                {
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
    }
    #endregion FillGridView

    #region Grid Row Command
    protected void gvHospitalList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteHospital(Convert.ToInt32(e.CommandArgument));
            FillHospitalGridView();
        }
        #endregion Delete Record
    }
    #endregion Grid Row Command

    #endregion GridView

    #region Function - Delete Hospital
    private void DeleteHospital(Int32 @HospitalID)
    {
        SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString);
        try
        {
            objConnection.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConnection;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_HOS_Hospital_DeleteByPK";
            objCmd.Parameters.AddWithValue("@HospitalID", @HospitalID);

            objCmd.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }
        finally
        {
            if (objConnection.State == ConnectionState.Open)
                objConnection.Close();
        }
    }
    #endregion Function - Delete Hospital
}