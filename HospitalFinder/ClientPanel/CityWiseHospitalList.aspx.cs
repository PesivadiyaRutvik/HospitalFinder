﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ClientPanel_CityWiseHospitalList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
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
                    objCmd.CommandText = "PR_HOS_Hospital_CityWiseHospital";
                    objCmd.Parameters.AddWithValue("@CityID", Page.RouteData.Values["CityID"].ToString());
                    #endregion Prepare Command

                    SqlDataReader objSDR = objCmd.ExecuteReader();
                    DataTable dtState = new DataTable();
                    dtState.Load(objSDR);

                    rpHospitalListByStateName.DataSource = dtState;
                    rpHospitalListByStateName.DataBind();

                    //gvHospitalListByCityName.DataSource = dtState;
                    //gvHospitalListByCityName.DataBind();
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
}