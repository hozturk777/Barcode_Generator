using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barcode
{
    public partial class frmReport : Form
    {
        AppData.BarcodeDataTable _barCode;
        public frmReport(AppData.BarcodeDataTable code)
        {
            InitializeComponent();
            _barCode = code;

        }

        private void frmReport_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", dt());
            //reportDataSource.Name = "DataSet1";
            //reportDataSource.Value = _barCode;
            //reportViewer1.LocalReport.EnableExternalImages = true;
            reportViewer1.LocalReport.ReportPath = "C:\\Users\\VICTUS\\Desktop\\HÜSEYİN\\BarkodV2\\Barcode_Generator\\Barkod\\Barkod\\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            reportViewer1.RefreshReport();

            var setup = reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 1);
            reportViewer1.SetPageSettings(setup);

        }

        private DataTable dt()
        {
            DataTable data = new DataTable();
            data = _barCode;
            return data;
        }
    }
}
