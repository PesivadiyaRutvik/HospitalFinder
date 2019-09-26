using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Category_CategoryList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillCategoryGridView();
        }
    }
    #endregion Load Event

    #region GridView

    #region FillGridView
    private void FillCategoryGridView()
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
                    objCmd.CommandText = "PR_HOS_Category_SelectAll";
                    #endregion Prepare Command

                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    DataTable dtCategory = new DataTable();
                    dtCategory.Load(objSDR);

                    gvHospitalCategoryList.DataSource = dtCategory;
                    gvHospitalCategoryList.DataBind();
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
    protected void gvHospitalCategoryList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord" && e.CommandArgument != null)
        {
            DeleteCategory(Convert.ToInt32(e.CommandArgument));
            FillCategoryGridView();
        }
        #endregion Delete Record
    }
    #endregion Grid Row Command

    #endregion GridView

    #region Function - Delete Category
    private void DeleteCategory(Int32 @CategoryID)
    {
        SqlConnection objConnection = new SqlConnection(DatabaseConfig.ConnectionString);
        try
        {
            objConnection.Open();

            SqlCommand objCmd = new SqlCommand();
            objCmd.Connection = objConnection;
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_HOS_Category_DeleteByPK";
            objCmd.Parameters.AddWithValue("@CategoryID", @CategoryID);

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
    #endregion Function - Delete Category
}