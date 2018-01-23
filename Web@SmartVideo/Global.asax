<%@ Application Language="C#" %>
<%@ Import Namespace="Web_SmartVideo" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        ScriptResourceDefinition Popper = new ScriptResourceDefinition();
        Popper.CdnPath = "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js";
        Popper.Path = "~/Scripts/popper.min.js";
        Popper.DebugPath = "~/Scripts/popper.min.js";
        Popper.CdnPath = "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js";
        Popper.CdnDebugPath = "https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("popper", null, Popper);

        ScriptResourceDefinition JQuery = new ScriptResourceDefinition();
        JQuery.CdnPath = "https://code.jquery.com/jquery-3.2.1.slim.min.js";
        JQuery.Path = "~/Scripts/jquery-3.2.1.min.js";
        JQuery.DebugPath = "~/Scripts/jquery-3.2.1.js";
        JQuery.CdnPath = "https://code.jquery.com/jquery-3.2.1.slim.min.js";
        JQuery.CdnDebugPath = "https://code.jquery.com/jquery-3.2.1.slim.min.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, JQuery);

        ScriptResourceDefinition Bootstrap = new ScriptResourceDefinition();
        Bootstrap.CdnPath = "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js";
        Bootstrap.Path = "~/Scripts/bootstrap.min.js";
        Bootstrap.DebugPath = "~/Scripts/bootstrap.min.js";
        Bootstrap.CdnPath = "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js";
        Bootstrap.CdnDebugPath = "https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("bootstrap", null, Bootstrap);

        ScriptResourceDefinition FontAwesome = new ScriptResourceDefinition();
        FontAwesome.CdnPath = "https://use.fontawesome.com/releases/v5.0.2/js/all.js";
        FontAwesome.Path = "~/Scripts/all.js";
        FontAwesome.DebugPath = "~/Scripts/all.js";
        FontAwesome.CdnPath = "https://use.fontawesome.com/releases/v5.0.2/js/all.js";
        FontAwesome.CdnDebugPath = "https://use.fontawesome.com/releases/v5.0.2/js/all.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("fontawesome", null, FontAwesome);

        //HttpContext.Current.Session.Add("Page", 1);
        //HttpContext.Current.Session.Add("i", 1);
        
    }

</script>
