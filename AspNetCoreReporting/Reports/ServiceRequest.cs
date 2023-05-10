using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace AspNetCoreReporting.Reports
{
    public partial class ServiceRequest : DevExpress.XtraReports.UI.XtraReport
    {
        int groupCounter = 0;
        public ServiceRequest()
        {
            InitializeComponent();
        }

        private void PageHeader_BeforePrint(object sender, CancelEventArgs e)
        {
            groupCounter++;
        }
    }
}
