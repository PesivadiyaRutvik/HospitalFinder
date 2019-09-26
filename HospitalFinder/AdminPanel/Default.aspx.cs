using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class AdminPanel_Default : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblMessage.Text = "Hello Yash Bhatasana";
            lblMessage.ForeColor = Color.Red;
        }
    }
    #endregion Load Event
}