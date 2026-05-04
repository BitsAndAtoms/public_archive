namespace TechSupport.View
{
    partial class MainDashboard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.logoutLabelLink = new System.Windows.Forms.LinkLabel();
            this.loginUsername = new System.Windows.Forms.Label();
            this.addIncident = new System.Windows.Forms.TabPage();
            this.addIncidentUserControl1 = new TechSupport.UserControls.addIncidentUserControl();
            this.DashboardTabControl = new System.Windows.Forms.TabControl();
            this.reportOpenIncidents = new System.Windows.Forms.TabPage();
            this.displayOpenIncidents = new System.Windows.Forms.TabPage();
            this.displayOpenIncidentsUserControl1 = new TechSupport.UserControls.displayOpenIncidentsUserControl();
            this.updateIncident = new System.Windows.Forms.TabPage();
            this.updateIncidentUserControl1 = new TechSupport.UserControls.updateIncidentUserControl();
            this.viewIncidentsByTechnician = new System.Windows.Forms.TabPage();
            this.viewIncidentsByTechnician1 = new TechSupport.UserControls.viewIncidentsByTechnician();
            this.openTechIncidentReportUserControl1 = new TechSupport.UserControls.OpenTechIncidentReportUserControl();
            this.tableLayoutPanel1.SuspendLayout();
            this.addIncident.SuspendLayout();
            this.DashboardTabControl.SuspendLayout();
            this.reportOpenIncidents.SuspendLayout();
            this.displayOpenIncidents.SuspendLayout();
            this.updateIncident.SuspendLayout();
            this.viewIncidentsByTechnician.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.13044F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.86956F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel1.Controls.Add(this.logoutLabelLink, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.loginUsername, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(622, 42);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // logoutLabelLink
            // 
            this.logoutLabelLink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.logoutLabelLink.AutoSize = true;
            this.logoutLabelLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutLabelLink.Location = new System.Drawing.Point(525, 9);
            this.logoutLabelLink.Name = "logoutLabelLink";
            this.logoutLabelLink.Size = new System.Drawing.Size(68, 24);
            this.logoutLabelLink.TabIndex = 13;
            this.logoutLabelLink.TabStop = true;
            this.logoutLabelLink.Text = "Logout";
            this.logoutLabelLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.logoutLabelLink_LinkClicked);
            // 
            // loginUsername
            // 
            this.loginUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.loginUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginUsername.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.loginUsername.Location = new System.Drawing.Point(3, 6);
            this.loginUsername.Name = "loginUsername";
            this.loginUsername.Size = new System.Drawing.Size(288, 30);
            this.loginUsername.TabIndex = 14;
            this.loginUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // addIncident
            // 
            this.addIncident.Controls.Add(this.addIncidentUserControl1);
            this.addIncident.Location = new System.Drawing.Point(4, 29);
            this.addIncident.Name = "addIncident";
            this.addIncident.Size = new System.Drawing.Size(614, 457);
            this.addIncident.TabIndex = 4;
            this.addIncident.Text = "Add Incident";
            this.addIncident.UseVisualStyleBackColor = true;
            // 
            // addIncidentUserControl1
            // 
            this.addIncidentUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addIncidentUserControl1.Location = new System.Drawing.Point(0, 0);
            this.addIncidentUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addIncidentUserControl1.Name = "addIncidentUserControl1";
            this.addIncidentUserControl1.Size = new System.Drawing.Size(614, 457);
            this.addIncidentUserControl1.TabIndex = 0;
            // 
            // DashboardTabControl
            // 
            this.DashboardTabControl.CausesValidation = false;
            this.DashboardTabControl.Controls.Add(this.reportOpenIncidents);
            this.DashboardTabControl.Controls.Add(this.displayOpenIncidents);
            this.DashboardTabControl.Controls.Add(this.addIncident);
            this.DashboardTabControl.Controls.Add(this.updateIncident);
            this.DashboardTabControl.Controls.Add(this.viewIncidentsByTechnician);
            this.DashboardTabControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DashboardTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardTabControl.Location = new System.Drawing.Point(0, 40);
            this.DashboardTabControl.Margin = new System.Windows.Forms.Padding(6);
            this.DashboardTabControl.Name = "DashboardTabControl";
            this.DashboardTabControl.SelectedIndex = 0;
            this.DashboardTabControl.Size = new System.Drawing.Size(622, 490);
            this.DashboardTabControl.TabIndex = 0;
            this.DashboardTabControl.TabStop = false;
            this.DashboardTabControl.SelectedIndexChanged += new System.EventHandler(this.DashboardTabControl_SelectedIndexChanged);
            // 
            // reportOpenIncidents
            // 
            this.reportOpenIncidents.Controls.Add(this.openTechIncidentReportUserControl1);
            this.reportOpenIncidents.Location = new System.Drawing.Point(4, 29);
            this.reportOpenIncidents.Name = "reportOpenIncidents";
            this.reportOpenIncidents.Size = new System.Drawing.Size(614, 457);
            this.reportOpenIncidents.TabIndex = 7;
            this.reportOpenIncidents.Text = "Open Incidents Report";
            this.reportOpenIncidents.UseVisualStyleBackColor = true;
            // 
            // displayOpenIncidents
            // 
            this.displayOpenIncidents.Controls.Add(this.displayOpenIncidentsUserControl1);
            this.displayOpenIncidents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayOpenIncidents.Location = new System.Drawing.Point(4, 29);
            this.displayOpenIncidents.Name = "displayOpenIncidents";
            this.displayOpenIncidents.Size = new System.Drawing.Size(614, 457);
            this.displayOpenIncidents.TabIndex = 5;
            this.displayOpenIncidents.Text = "Display Open Incidents";
            this.displayOpenIncidents.UseVisualStyleBackColor = true;
            // 
            // displayOpenIncidentsUserControl1
            // 
            this.displayOpenIncidentsUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayOpenIncidentsUserControl1.Location = new System.Drawing.Point(0, 0);
            this.displayOpenIncidentsUserControl1.Name = "displayOpenIncidentsUserControl1";
            this.displayOpenIncidentsUserControl1.Size = new System.Drawing.Size(614, 457);
            this.displayOpenIncidentsUserControl1.TabIndex = 0;
            this.displayOpenIncidentsUserControl1.Load += new System.EventHandler(this.MainDashboard_Load);
            // 
            // updateIncident
            // 
            this.updateIncident.Controls.Add(this.updateIncidentUserControl1);
            this.updateIncident.Location = new System.Drawing.Point(4, 29);
            this.updateIncident.Margin = new System.Windows.Forms.Padding(6);
            this.updateIncident.Name = "updateIncident";
            this.updateIncident.Size = new System.Drawing.Size(614, 457);
            this.updateIncident.TabIndex = 2;
            this.updateIncident.Text = "Update";
            this.updateIncident.UseVisualStyleBackColor = true;
            // 
            // updateIncidentUserControl1
            // 
            this.updateIncidentUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateIncidentUserControl1.Location = new System.Drawing.Point(0, 0);
            this.updateIncidentUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.updateIncidentUserControl1.Name = "updateIncidentUserControl1";
            this.updateIncidentUserControl1.Size = new System.Drawing.Size(614, 457);
            this.updateIncidentUserControl1.TabIndex = 0;
            // 
            // viewIncidentsByTechnician
            // 
            this.viewIncidentsByTechnician.Controls.Add(this.viewIncidentsByTechnician1);
            this.viewIncidentsByTechnician.Location = new System.Drawing.Point(4, 29);
            this.viewIncidentsByTechnician.Name = "viewIncidentsByTechnician";
            this.viewIncidentsByTechnician.Size = new System.Drawing.Size(614, 457);
            this.viewIncidentsByTechnician.TabIndex = 6;
            this.viewIncidentsByTechnician.Text = "View Incidents by Technician";
            this.viewIncidentsByTechnician.UseVisualStyleBackColor = true;
            // 
            // viewIncidentsByTechnician1
            // 
            this.viewIncidentsByTechnician1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewIncidentsByTechnician1.Location = new System.Drawing.Point(0, 0);
            this.viewIncidentsByTechnician1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.viewIncidentsByTechnician1.Name = "viewIncidentsByTechnician1";
            this.viewIncidentsByTechnician1.Size = new System.Drawing.Size(614, 457);
            this.viewIncidentsByTechnician1.TabIndex = 0;
            // 
            // openTechIncidentReportUserControl1
            // 
            this.openTechIncidentReportUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openTechIncidentReportUserControl1.Location = new System.Drawing.Point(0, 0);
            this.openTechIncidentReportUserControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openTechIncidentReportUserControl1.Name = "openTechIncidentReportUserControl1";
            this.openTechIncidentReportUserControl1.Size = new System.Drawing.Size(614, 457);
            this.openTechIncidentReportUserControl1.TabIndex = 0;
            // 
            // MainDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(622, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DashboardTabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "MainDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainDashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.exitForm);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.addIncident.ResumeLayout(false);
            this.DashboardTabControl.ResumeLayout(false);
            this.reportOpenIncidents.ResumeLayout(false);
            this.displayOpenIncidents.ResumeLayout(false);
            this.updateIncident.ResumeLayout(false);
            this.viewIncidentsByTechnician.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel logoutLabelLink;
        private System.Windows.Forms.Label loginUsername;
        private System.Windows.Forms.TabPage addIncident;
        private System.Windows.Forms.TabControl DashboardTabControl;
        private System.Windows.Forms.TabPage displayOpenIncidents;
        private System.Windows.Forms.TabPage updateIncident;
        private UserControls.displayOpenIncidentsUserControl displayOpenIncidentsUserControl1;
        private UserControls.addIncidentUserControl addIncidentUserControl1;
        private UserControls.updateIncidentUserControl updateIncidentUserControl1;
        private System.Windows.Forms.TabPage viewIncidentsByTechnician;
        private UserControls.viewIncidentsByTechnician viewIncidentsByTechnician1;
        private System.Windows.Forms.TabPage reportOpenIncidents;
        private UserControls.OpenTechIncidentReportUserControl openTechIncidentReportUserControl1;
    }
}