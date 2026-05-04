
using System.Collections.Generic;
using System.Data.SqlClient;
using TechSupport.Model;

namespace TechSupport.DAL
{
    class TechnicianDBDAL
    {
        /// <summary>
        /// This method fethces the technicians with open incidents
        /// </summary>
        /// <returns>a list of Technicians</returns>
        public List<Technician> GETTechnicianWithOpenIncidents()
        {
            List<Technician> TechnicianList = new List<Technician>();
            string selectStatement =
                "SELECT NAME AS Technician, Phone, Email, a.TechID " +
                "FROM[TechSupport].[dbo].[Technicians] a " +
                "INNER JOIN (SELECT DISTINCT t1.TechID " +
                "FROM [TechSupport].[dbo].[Technicians] t1 " +
                "INNER JOIN [TechSupport].[dbo].[Incidents] t2 " +
                "ON t1.TechID = t2.TechID " +
                "WHERE [DateClosed] IS NUll" +
                ") " +
                "AS b ON a.TechID =b.TechID";

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Technician Technician = new Technician();
                            Technician.TechID = (int)reader["TechID"];
                            Technician.Email = reader["Email"].ToString();
                            Technician.Phone = reader["Phone"].ToString();
                            Technician.TechnicianName = reader["Technician"].ToString();
                            TechnicianList.Add(Technician);
                        }
                    }
                }
            }
            return TechnicianList;
        }
    }
}
