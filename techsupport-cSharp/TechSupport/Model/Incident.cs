using System;

namespace TechSupport.Model
{
    /// <summary>
    /// This class creates an incident object with
    /// title, description and customerID as properties
    /// </summary>
    public class Incident
    {
        
        /// <summary>
        /// name of the customer get set
        /// </summary>
       public string CustomerName { get; set; }

        /// <summary>
        /// incident closed date get set
        /// </summary>
        public string DateClosed { get; set; }


        /// <summary>
        /// incident filed date get set
        /// </summary>
        public string DateOpened { get; set; }

        /// <summary>
        /// product code get set
        /// </summary>
        public string ProductCode { get; set; }

        /// <summary>
        /// product name get set
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// title of the incident get set
        /// </summary>
        public string Title { get; set;}

        /// <summary>
        /// description of the incident get set
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// customerID of the incident get set
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// incidentID of the incident get set
        /// </summary>
        public int IncidentID { get; set; }

        /// <summary>
        /// technician of the incident get set
        /// </summary>
        public string TechnicianName { get; set; }
    
    }
}
