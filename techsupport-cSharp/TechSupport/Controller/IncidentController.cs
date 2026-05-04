using System;
using System.Collections.Generic;
using TechSupport.DAL;
using TechSupport.Model;

namespace TechSupport.Controller
{
    /// <summary>
    /// This controller class interacts with the incident data source
    /// and performs all the operations on the incident data source.
    /// </summary>
    public class IncidentController
    {
        
        private IncidentDBDAL incidentDBSource;
        /// <summary>
        /// constructor for incident controller 
        /// instantiates a incident DAL object
        /// </summary>
        public IncidentController()
        {
            
            this.incidentDBSource = new IncidentDBDAL();
        }

       


        /// <summary>
        /// method to access the list of technicians available in DB
        /// </summary>
        /// <returns>Current list of technicians </returns>
        public List<string> GETTechnicianListFromDB()
        {
            return this.incidentDBSource.GETTechnicianListFromDB();
        }

        /// <summary>
        /// method to access the list of registered customer
        /// along with their registered products as a dictionary
        /// </summary>
        /// <returns>Dictionary list of registered customers as keys and products as values </returns>
        public Dictionary<string, List<string>> GetRegisteredDBCustomersAndProducts()
        {
            return this.incidentDBSource.GETRegisteredDBCustomersWithProducts();
        }

        /// <summary>
        /// method to access the list of customer incidents in database
        /// maintained by the incidentDBDAL
        /// </summary>
        /// <returns>Current list of incidents </returns>
        public List<Incident> GetCustomerDBIncidents()
        {
            return this.incidentDBSource.GETCustomerDBIncidents();
        }

        /// <summary>
        /// method to add a new incident to the incident list in the databse
        /// </summary>
        /// <param name="incident"> The incident to be added to the list</param>
        public Incident getIncidentFromDBbyID(Incident incident)
        {
            if (incident == null)
            {
                throw new ArgumentException("Incident can not be null");
            }
            return this.incidentDBSource.getIncidentFromDBbyID(incident);
        }


        /// <summary>
        /// method to add a new incident to the incident list in the databse
        /// </summary>
        /// <param name="incident"> The incident to be added to the list</param>
        public void updateIncidentInDB(Incident incident, Incident retrivedIncident)
        {
            if (incident == null)
            {
                throw new ArgumentException("Incident can not be null");
            }
            this.incidentDBSource.updateIncidentInDB(incident, retrivedIncident);
        }

        /// <summary>
        /// method to get open incidents in the database by technician name
        /// </summary>
        /// <param name="newTechnician"> The technician\</param>
        public List<Incident> GetOpenDBIncidentsForTechnicianID(Technician newTechnician)
        {
            return this.incidentDBSource.GETOpenIncidentsForTechnicianID(newTechnician);
        }




        /// <summary>
        /// method to add a new incident to the incident list in the databse
        /// </summary>
        /// <param name="incident"> The incident to be added to the list</param>
        public void AddIncidentToDB(Incident incident)
        {
            if (incident == null)
            {
                throw new ArgumentException("Incident can not be null");
            }
            this.incidentDBSource.AddIncidentToDB(incident);
        }

        

    }
}
