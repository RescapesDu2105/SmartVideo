using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web_SmartVideo;

public partial class Account_Rentals : Page
{
    public SmartWCFServiceReference.SmartWCFServiceClient Service
    {
        get { return Service; }
        private set
        {
            Service = new SmartWCFServiceReference.SmartWCFServiceClient();
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        //Response.Write("Init<br/>");

        //Response.Write("Count = " + Service.GetLocationsClient(Session["LocationsClient"] != null ? Session["LocationsClient"].ToString() : "null").Count());
        //Response.Write("Count = " + Service.GetLocationsClient(Session["ClientId"] != null ? Session["ClientId"].ToString() : "null").Count());
    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        
    }

    protected void ReturnOnHomePage(object sender, EventArgs e)
    {
        IdentityHelper.RedirectToReturnUrl("~/", Response);
    }
}