using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TechSupport.Controller;
using TechSupport.Model;

namespace TechSupport.UserControls
{
    public partial class viewIncidentsByTechnician : UserControl
    {
        private TechnicianController newTechnicianController;
        private IncidentController newIncidentController;
        private List<Technician> technicianList;
        private List<Incident> incidentList;

        /// <summary>
        /// Default constructor for user control viewIncidensByTechnician
        /// </summary>
        public viewIncidentsByTechnician()
        {
            InitializeComponent();
            newTechnicianController = new TechnicianController();
            newIncidentController = new IncidentController();
        }

        /// <summary>
        /// FOrm load populates combobox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void viewIncidentsByTechnician_Load(object sender, EventArgs e)
        {
            try
            {
                this.technicianList = newTechnicianController.GETTechnicianListFromDBWithOpenIncidents();
                technicianNameComboBox.DataSource = technicianList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Technician name upon selection populates, contact details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void technicianNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (technicianNameComboBox.SelectedIndex < 0)
            {
                return;
            }
            try
            {
            Technician technician = this.technicianList[technicianNameComboBox.SelectedIndex];
            technicianBindingSource.Clear();
            technicianBindingSource.Add(technician);
            incidentBindingSource.Clear();
            this.incidentList = this.newIncidentController.GetOpenDBIncidentsForTechnicianID(technician);
            incidentBindingSource.DataSource = incidentList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex.Message,
                    "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
