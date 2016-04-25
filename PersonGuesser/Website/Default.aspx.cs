using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Website
{
    public partial class _Default : Page
    {
        public string MainWindowVisibility { get; set; } = "none";

        public string StartWindowVisibility { get; set; } = "";

        public string EndWindowVisibility { get; set; } = "none";

        //other visibilites

        protected void Page_Load(object sender, EventArgs e)
        {
            var context = HttpContext.Current;
            context.Session.Add("dupa", 0);
        }

        protected void YesEventHandler(object sender, EventArgs e)
        {

        }

        protected void NoEventHandler(object sender, EventArgs e)
        {
            StartWindowVisibility = "none";
            EndWindowVisibility = "";
            MainWindowVisibility = "none";
            
        }

        protected void DkEventHandler(object sender, EventArgs e)
        {
            StartWindowVisibility = "";
            MainWindowVisibility = "none";
        }

        protected void StartGameEventHandler(object sender, EventArgs e)
        {
            StartWindowVisibility = "none";
            MainWindowVisibility = "";
        }

        protected void ReturnToStartEventHandler(object sender, EventArgs e)
        {
            StartWindowVisibility = "";
            EndWindowVisibility = "none";
            MainWindowVisibility = "none";
        }
    }
}