namespace TechSupport.UserControls
{
    partial class addIncidentUserControl
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
            this.tableLayoutPanelIncident = new System.Windows.Forms.TableLayoutPanel();
            this.cancelAddIncident = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.addIncidentButton = new System.Windows.Forms.Button();
            this.customerNameComboBox = new System.Windows.Forms.ComboBox();
            this.customerLabel = new System.Windows.Forms.Label();
            this.productLabel = new System.Windows.Forms.Label();
            this.productNameComboBox = new System.Windows.Forms.ComboBox();
            this.descritionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelIncident.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelIncident
            // 
            this.tableLayoutPanelIncident.ColumnCount = 2;
            this.tableLayoutPanelIncident.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelIncident.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelIncident.Controls.Add(this.cancelAddIncident, 0, 4);
            this.tableLayoutPanelIncident.Controls.Add(this.titleLabel, 0, 2);
            this.tableLayoutPanelIncident.Controls.Add(this.addIncidentButton, 0, 4);
            this.tableLayoutPanelIncident.Controls.Add(this.customerNameComboBox, 1, 0);
            this.tableLayoutPanelIncident.Controls.Add(this.customerLabel, 0, 0);
            this.tableLayoutPanelIncident.Controls.Add(this.productLabel, 0, 1);
            this.tableLayoutPanelIncident.Controls.Add(this.productNameComboBox, 1, 1);
            this.tableLayoutPanelIncident.Controls.Add(this.descritionLabel, 0, 3);
            this.tableLayoutPanelIncident.Controls.Add(this.descriptionTextBox, 1, 3);
            this.tableLayoutPanelIncident.Controls.Add(this.titleTextBox, 1, 2);
            this.tableLayoutPanelIncident.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelIncident.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelIncident.Name = "tableLayoutPanelIncident";
            this.tableLayoutPanelIncident.RowCount = 5;
            this.tableLayoutPanelIncident.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanelIncident.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.26882F));
            this.tableLayoutPanelIncident.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.73119F));
            this.tableLayoutPanelIncident.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanelIncident.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanelIncident.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelIncident.Size = new System.Drawing.Size(507, 408);
            this.tableLayoutPanelIncident.TabIndex = 0;
            this.tableLayoutPanelIncident.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanelIncident_Paint);
            // 
            // cancelAddIncident
            // 
            this.cancelAddIncident.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelAddIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelAddIncident.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.cancelAddIncident.Location = new System.Drawing.Point(80, 371);
            this.cancelAddIncident.Name = "cancelAddIncident";
            this.cancelAddIncident.Size = new System.Drawing.Size(92, 29);
            this.cancelAddIncident.TabIndex = 6;
            this.cancelAddIncident.Text = "Reset";
            this.cancelAddIncident.UseVisualStyleBackColor = true;
            this.cancelAddIncident.Click += new System.EventHandler(this.resetIncidentTabButton_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(101, 168);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(50, 24);
            this.titleLabel.TabIndex = 6;
            this.titleLabel.Text = "Title:";
            // 
            // addIncidentButton
            // 
            this.addIncidentButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addIncidentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addIncidentButton.Location = new System.Drawing.Point(334, 371);
            this.addIncidentButton.Name = "addIncidentButton";
            this.addIncidentButton.Size = new System.Drawing.Size(92, 29);
            this.addIncidentButton.TabIndex = 5;
            this.addIncidentButton.Text = "Add";
            this.addIncidentButton.UseVisualStyleBackColor = true;
            this.addIncidentButton.Click += new System.EventHandler(this.addIncidentButton_Click);
            // 
            // customerNameComboBox
            // 
            this.customerNameComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.customerNameComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerNameComboBox.FormattingEnabled = true;
            this.customerNameComboBox.Location = new System.Drawing.Point(271, 14);
            this.customerNameComboBox.Name = "customerNameComboBox";
            this.customerNameComboBox.Size = new System.Drawing.Size(218, 28);
            this.customerNameComboBox.TabIndex = 1;
            this.customerNameComboBox.SelectedValueChanged += new System.EventHandler(this.customerNameComboBox_SelectedValueChanged);
            // 
            // customerLabel
            // 
            this.customerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.customerLabel.AutoSize = true;
            this.customerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerLabel.Location = new System.Drawing.Point(78, 16);
            this.customerLabel.Name = "customerLabel";
            this.customerLabel.Size = new System.Drawing.Size(96, 24);
            this.customerLabel.TabIndex = 4;
            this.customerLabel.Text = "Customer:";
            // 
            // productLabel
            // 
            this.productLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productLabel.AutoSize = true;
            this.productLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLabel.Location = new System.Drawing.Point(84, 69);
            this.productLabel.Name = "productLabel";
            this.productLabel.Size = new System.Drawing.Size(85, 24);
            this.productLabel.TabIndex = 13;
            this.productLabel.Text = "Product :";
            // 
            // productNameComboBox
            // 
            this.productNameComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.productNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productNameComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productNameComboBox.FormattingEnabled = true;
            this.productNameComboBox.Location = new System.Drawing.Point(272, 67);
            this.productNameComboBox.Name = "productNameComboBox";
            this.productNameComboBox.Size = new System.Drawing.Size(216, 28);
            this.productNameComboBox.TabIndex = 2;
            // 
            // descritionLabel
            // 
            this.descritionLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descritionLabel.AutoSize = true;
            this.descritionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descritionLabel.Location = new System.Drawing.Point(72, 297);
            this.descritionLabel.Name = "descritionLabel";
            this.descritionLabel.Size = new System.Drawing.Size(109, 24);
            this.descritionLabel.TabIndex = 8;
            this.descritionLabel.Text = "Description:";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.descriptionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTextBox.Location = new System.Drawing.Point(270, 270);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTextBox.Size = new System.Drawing.Size(220, 78);
            this.descriptionTextBox.TabIndex = 4;
            // 
            // titleTextBox
            // 
            this.titleTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(267, 167);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(225, 26);
            this.titleTextBox.TabIndex = 3;
            // 
            // addIncidentUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelIncident);
            this.Name = "addIncidentUserControl";
            this.Size = new System.Drawing.Size(507, 408);
            this.tableLayoutPanelIncident.ResumeLayout(false);
            this.tableLayoutPanelIncident.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelIncident;
        private System.Windows.Forms.Label customerLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label descritionLabel;
        private System.Windows.Forms.Button addIncidentButton;
        private System.Windows.Forms.Button cancelAddIncident;
        private System.Windows.Forms.ComboBox customerNameComboBox;
        private System.Windows.Forms.Label productLabel;
        private System.Windows.Forms.ComboBox productNameComboBox;
        private System.Windows.Forms.TextBox titleTextBox;
    }
}
