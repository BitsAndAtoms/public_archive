namespace TechSupport.UserControls
{
    partial class OpenTechIncidentReportUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.openIncidentsByTechnicianDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.techSupportDataSet = new TechSupport.TechSupportDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.openIncidentsByTechnicianDataTableAdapter = new TechSupport.TechSupportDataSetTableAdapters.OpenIncidentsByTechnicianDataTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.openIncidentsByTechnicianDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // openIncidentsByTechnicianDataBindingSource
            // 
            this.openIncidentsByTechnicianDataBindingSource.DataMember = "OpenIncidentsByTechnicianData";
            this.openIncidentsByTechnicianDataBindingSource.DataSource = this.techSupportDataSet;
            // 
            // techSupportDataSet
            // 
            this.techSupportDataSet.DataSetName = "TechSupportDataSet";
            this.techSupportDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "OpenTechIncidents";
            reportDataSource1.Value = this.openIncidentsByTechnicianDataBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TechSupport.OpenTechSupportReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(350, 328);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // openIncidentsByTechnicianDataTableAdapter
            // 
            this.openIncidentsByTechnicianDataTableAdapter.ClearBeforeFill = true;
            // 
            // OpenTechIncidentReportUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Name = "OpenTechIncidentReportUserControl";
            this.Size = new System.Drawing.Size(350, 328);
            ((System.ComponentModel.ISupportInitialize)(this.openIncidentsByTechnicianDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.techSupportDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource openIncidentsByTechnicianDataBindingSource;
        private TechSupportDataSet techSupportDataSet;
        private TechSupportDataSetTableAdapters.OpenIncidentsByTechnicianDataTableAdapter openIncidentsByTechnicianDataTableAdapter;
    }
}
