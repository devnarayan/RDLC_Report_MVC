using ASPNETMVC_SSRS_Demo.ViewModel;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPNETMVC_SSRS_Demo.Reports
{
    public partial class ReportTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //String reportFolder = System.Configuration.ConfigurationManager.AppSettings["SSRSReportsFolder"].ToString();

                    //rvSiteMapping.Height = Unit.Pixel(Convert.ToInt32(Request["Height"]) - 58);
                    //rvSiteMapping.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;

                    //rvSiteMapping.ServerReport.ReportServerUrl = new Uri("SSRS URL"); // Add the Reporting Server URL
                    //rvSiteMapping.ServerReport.ReportPath = String.Format("/{0}/{1}", reportFolder, Request["ReportName"].ToString());

                    //rvSiteMapping.ServerReport.Refresh();

                    //RDLC
                    string searchText = string.Empty;

                    if (Request.QueryString["searchText"] != null)
                    {
                        searchText = Request.QueryString["searchText"].ToString();
                    }

                    List<ApplicationViewModel> applications = new List<ApplicationViewModel>();
                    using (var _context = new Models.WorkpulseGSMEntities())
                    {
                        //applications = _context.MstApplications.Select(st => new ApplicationViewModel
                        //{
                        //    Id = st.Id,
                        //    AppName = st.AppName,
                        //    DisplayName = st.DisplayName,
                        //    SourceId = st.SourceId
                        //}).OrderBy(a => a.AppName).ToList();
                        applications.Add(new ApplicationViewModel
                        {
                            Id = 1,
                            AppName = "App",
                            DisplayName = "Dis App"
                        });
                        applications.Add(new ApplicationViewModel
                        {
                            Id = 2,
                            AppName = "App 2",
                            DisplayName = "Dis App 2"
                        });

                        ApplicationListReportViewer.LocalReport.ReportPath = Server.MapPath("~/Reports/Report1.rdlc");
                        ApplicationListReportViewer.LocalReport.DataSources.Clear();
                        ReportDataSource rdc = new ReportDataSource("EmployeeDataSet", applications);
                        ApplicationListReportViewer.LocalReport.DataSources.Add(rdc);
                        ApplicationListReportViewer.LocalReport.Refresh();
                        ApplicationListReportViewer.DataBind();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}