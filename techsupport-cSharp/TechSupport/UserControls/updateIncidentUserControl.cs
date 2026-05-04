using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TechSupport.Controller;
using TechSupport.Model;

namespace TechSupport.UserControls
{
    public partial class updateIncidentUserControl : UserControl
    {
        private readonly IncidentController incidentController;
        private int IncidentID;
        
        /// <summary>
        /// constructor for the searchIncidentUserControl form
        /// </summary>
        public updateIncidentUserControl()
        {
            InitializeComponent();
            this.incidentController = new IncidentController();
        }

        private void getIncidentButton_Click(object sender, EventArgs e)
        {
            this.updateButton.Enabled = true;
            this.closeButton.Enabled = true;
            Incident newIncident = new Incident();
            try
            {
                newIncident.IncidentID = Convert.ToInt32(this.incidentIDTextBox.Text);
                newIncident = this.incidentController.getIncidentFromDBbyID(newIncident);

                if (!string.IsNullOrEmpty(newIncident.DateClosed))
                {
                    this.updateButton.Enabled = false;
                    this.closeButton.Enabled = false;
                }

                if (newIncident.CustomerName == null)
                {
                    throw new System.ArgumentException("No incident found for the selected ID");
                }

              
                
                
                else
                {
                    this.customerNameTextBox.Text = newIncident.CustomerName;
                    this.descriptionTextBox.Text = newIncident.Description;
                    this.titleTextBox.Text = newIncident.Title;
                    this.dateOpenedTextBox.Text = newIncident.DateOpened;
                    this.productNameTextBox.Text = newIncident.ProductCode;
                    List<string> TechnicianList = new System.Collections.Generic.List<string>(this.incidentController.GETTechnicianListFromDB());
                    TechnicianList.Insert(0, "--Unassigned--");
                    this.technicianNameComboBox.DataSource = TechnicianList;
                    this.technicianNameComboBox.SelectedIndex = Math.Max(this.technicianNameComboBox.Items.IndexOf(newIncident.TechnicianName), 0);
                    this.IncidentID = newIncident.IncidentID;

                }
            }
            catch (Exception ex)
            {
                this.clearButton_Click(null, null);
                MessageBox.Show("" + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Method to update the record based on entered incident data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            Incident newIncident = new Incident(); 
            newIncident.IncidentID = this.IncidentID;
            
            try
            {
                newIncident = this.incidentController.getIncidentFromDBbyID(newIncident);
                Incident retrivedIncident= this.incidentController.getIncidentFromDBbyID(newIncident);
                if (string.IsNullOrEmpty(this.editDescriptionTextBox.Text))
                {
                    throw new System.ArgumentException("Text to add field is empty. Description will not be updated ");
                }
                
               
                if (newIncident.Description.Length < 200)
                {
                    newIncident.Description = newIncident.Description + Environment.NewLine + "<" +
                    DateTime.Today.ToString("MM/dd/yyyy") + ">" +
                    this.editDescriptionTextBox.Text;
                    if (newIncident.Description.Length > 200)
                    {
                        DialogResult dialogResult = MessageBox.Show("Only 200 character allowed. New description will be truncated", "Character limit", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            newIncident.Description = newIncident.Description.Substring(0, 200);
                            if (this.technicianNameComboBox.SelectedIndex != 0)
                            {
                                newIncident.TechnicianName = this.technicianNameComboBox.Text;
                            }
                            this.incidentController.updateIncidentInDB(newIncident, retrivedIncident);
                            this.editDescriptionTextBox.Text = "";
                            this.descriptionTextBox.Text = newIncident.Description;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                           
                        }
                    }
                    else
                    {
                        if (this.technicianNameComboBox.SelectedIndex != 0)
                        {
                            newIncident.TechnicianName = this.technicianNameComboBox.Text;
                        }
                        this.incidentController.updateIncidentInDB(newIncident, retrivedIncident);
                        this.editDescriptionTextBox.Text = "";
                        this.descriptionTextBox.Text = newIncident.Description;
                    }

                }
                else {
                    MessageBox.Show("Description is already 200 characters. No further " +
                        " edition possible. Only technician name will be updated" ,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (this.technicianNameComboBox.SelectedIndex != 0)
                    {
                        newIncident.TechnicianName = this.technicianNameComboBox.Text;
                    }
                    this.incidentController.updateIncidentInDB(newIncident, retrivedIncident);
                    this.editDescriptionTextBox.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.technicianNameComboBox.DataSource = null;
            this.incidentIDTextBox.Text = "";
            this.customerNameTextBox.Text = "";
            this.descriptionTextBox.Text = "";
            this.titleTextBox.Text = "";
            this.dateOpenedTextBox.Text = "";
            this.productNameTextBox.Text = "";
            this.editDescriptionTextBox.Text = "";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Form can not be updated once closed. Confirm that you want to close", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try {
                    this.updateButton_Click(sender, null); 
                    Incident retrivedIncident1 = new Incident();
                    retrivedIncident1.IncidentID = this.IncidentID;
                    retrivedIncident1 = this.incidentController.getIncidentFromDBbyID(retrivedIncident1);
                    Incident  newIncident = this.incidentController.getIncidentFromDBbyID(retrivedIncident1);
                    
                    if (String.IsNullOrEmpty(newIncident.TechnicianName))
                    {
                    throw new System.ArgumentException("Can not be closed without assigning" +
                        " Technician ");
                     }

                     newIncident.DateClosed = DateTime.Now.ToString();
                     this.incidentController.updateIncidentInDB(newIncident, retrivedIncident1);
                     this.editDescriptionTextBox.Text = "";
                     this.descriptionTextBox.Text = newIncident.Description;
                     this.updateButton.Enabled = false;
                     this.closeButton.Enabled = false;
            } catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            else if (dialogResult == DialogResult.No)
            {
            }

        }
    }
}
