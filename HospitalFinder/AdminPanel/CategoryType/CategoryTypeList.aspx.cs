using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_CategoryType_CategoryTypeList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCategoryTypeGridView();
        }
    }
    #endregion Load Event

    #region GridView

    #region FillGridView
    private void FillCategoryTypeGridView()
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
                    objCmd.CommandText = "PR_HOS_CategoryType_SelectAll";
                    #endregion Prepare Command

                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    DataTable dtCategoryType = new DataTable();
                    dtCategoryType.Load(objSDR);

                    gvHospitalCategoryTypeList.DataSource = dtCategoryType;
                    gvHospitalCategoryTypeList.DataBind();
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
    protected void gvHospitalCategoryTypeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteCategoryType(Convert.ToInt32(e.CommandArgument));
            FillCategoryTypeGridView();
        }
        #endregion Delete Record
    }
    #endregion Grid Row Command

    #endregion GridView

    #region Function - Delete CategoryType
    private void DeleteCategoryType(Int32 @CategoryTypeID)
    {
        SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString);
        try
        {
            objConnection.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConnection;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_HOS_CategoryType_DeleteByPK";
            objCmd.Parameters.AddWithValue("@CategoryTypeID", @CategoryTypeID);

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
    #endregion Function - Delete CategoryType
}