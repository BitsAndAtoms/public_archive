using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TechSupport.Controller;
using TechSupport.Model;

namespace TechSupport.UserControls
{
    public partial class addIncidentUserControl : UserControl
    {
        private readonly IncidentController incidentController;
        /// <summary>
        /// constructor for add incident user control form
        /// </summary>
        public addIncidentUserControl()
        {
            InitializeComponent();
            this.incidentController = new IncidentController();
            this.LoadCustomerNameComboBox();
        }

        /// <summary>
        /// Add incident button adds the incident to the test data list or 
        /// throws the necessary exception
        /// </summary>
        ///param name="e"> e is the even arg</param>
        private void addIncidentButton_Click(object sender, EventArgs e)
        {
            try
            {
                Incident newIncident = new Incident();
                newIncident.Title = this.titleTextBox.Text;
                newIncident.Description = this.descriptionTextBox.Text;
                newIncident.CustomerName = this.customerNameComboBox.SelectedValue.ToString();
                newIncident.ProductName = this.productNameComboBox.SelectedValue.ToString();
                newIncident.DateOpened = DateTime.Now.ToString();
                if (String.IsNullOrEmpty(newIncident.Title) || String.IsNullOrEmpty(newIncident.Description))
                {
                    throw new System.ArgumentException("Incident title/description can not be empty");
                }
                else {
                    this.incidentController.AddIncidentToDB(newIncident);
                    MessageBox.Show("Incident added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something is wrong with the input\n" + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cancel the indcident add dialog
        /// </summary>
        /// <param name="sender">sender is the event object</param>
        /// <param name="e"> e is the even arg</param>
        public void resetIncidentTabButton_Click(object sender, EventArgs e)
        {
           this.descriptionTextBox.Text = "";
            this.titleTextBox.Text = "";
            this.customerNameComboBox.SelectedIndex = 1;
        }

        private void LoadProductNameComboBox()
        {
            try
            {
                this.productNameComboBox.DataSource = null;
                this.productNameComboBox.DataSource = new List<string>(this.incidentController.GetRegisteredDBCustomersAndProducts()[this.customerNameComboBox.SelectedValue.ToString()]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning, cannot load product data at this time." + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads all the customers who have registered 
        /// These customers are eligible to file incidents
        /// </summary>
        private void LoadCustomerNameComboBox()
        {
            this.customerNameComboBox.DataSource = null;
            try
            {
                this.customerNameComboBox.DataSource = new List<string>(this.incidentController.GetRegisteredDBCustomersAndProducts().Keys);
                this.LoadProductNameComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning, cannot load customer data at this time." + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Refresh the products list
        /// as per the selection for the customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this.LoadProductNameComboBox();
        }

        private void tableLayoutPanelIncident_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
