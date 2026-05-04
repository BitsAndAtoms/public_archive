using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechSupport.UserControls
{
    public partial class OpenTechIncidentReportUserControl : UserControl
    {
        /// <summary>
        /// Initialize the constructor
        /// </summary>
        public OpenTechIncidentReportUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method fills the table upon load and refreshes it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportViewer1_Load(object sender, EventArgs e)
        {
            try { 
            this.openIncidentsByTechnicianDataTableAdapter.Fill(this.techSupportDataSet.OpenIncidentsByTechnicianData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// Refresh function added to the report navigator 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            try
            {
                this.openIncidentsByTechnicianDataTableAdapter.Fill(this.techSupportDataSet.OpenIncidentsByTechnicianData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.reportViewer1.RefreshReport();
        }
    }
}
