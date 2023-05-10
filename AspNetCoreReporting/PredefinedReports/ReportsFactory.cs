using AspNetCoreReporting.Reports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreReporting.PredefinedReports
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["ServiceRequest"] = () => new ServiceRequest(),
            ["Minutes"] = () => new Minutes(),
            ["MinuteAmh"] = () => new MinuteAmh(),
            ["Certificate"] = () => new Certificate()
        };
    }
}