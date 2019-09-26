using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCityGridView();
        }
    }
    #endregion Load Event

    #region GridView

    #region FillGridView
    private void FillCityGridView()
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
                    objCmd.CommandText = "PR_LOC_City_SelectAll";
                    #endregion Prepare Command

                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    DataTable dtCity = new DataTable();
                    dtCity.Load(objSDR);

                    gvCityList.DataSource = dtCity;
                    gvCityList.DataBind();
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
    protected void gvCityList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteCity(Convert.ToInt32(e.CommandArgument));
            FillCityGridView();
        }
        #endregion Delete Record
    }
    #endregion Grid Row Command

    #endregion GridView

    #region Function - Delete City
    private void DeleteCity(Int32 @CityID)
    {
        SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString);
        try
        {
            objConnection.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConnection;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_LOC_City_DeleteByPK";
            objCmd.Parameters.AddWithValue("@CityID", @CityID);

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
    #endregion Function - Delete City

}