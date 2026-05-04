using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TechSupport.Model;

namespace TechSupport.DAL
{
    class IncidentDBDAL
    {
        /// <summary>
        /// This method fethces the incident data
        /// </summary>
        /// <returns>a list of Incidents</returns>
        public List<Incident> GETCustomerDBIncidents()
        {
            List<Incident> IncidentList = new List<Incident>();
            string selectStatement =
                "SELECT [ProductCode]" +
                ", t1.CustomerID, t1.Description" +
                ", FORMAT([DateOpened],'MM/dd/yyyy') as 'DateOpened'" +
                ",t2.Name AS Customer" +
                ",t3.Name AS Technician" +
                ",[Title] FROM[TechSupport].[dbo].[Incidents] " +
                "t1 LEFT JOIN[TechSupport].[dbo].[Customers]" +
                " t2 ON t1.CustomerID = t2.CustomerID" +
                " LEFT JOIN[TechSupport].[dbo].[Technicians]" +
                " t3 ON t1.TechID = t3.TechID " +
                "WHERE [DateClosed] IS NUll";


            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Incident Incident = new Incident();
                            Incident.CustomerID = (int)reader["CustomerID"];
                            Incident.Title = reader["Title"].ToString();
                            Incident.Description = reader["Description"].ToString();
                            Incident.TechnicianName = reader["Technician"].ToString();
                            Incident.CustomerName = reader["Customer"].ToString();
                            Incident.DateOpened = reader["DateOpened"].ToString();
                            Incident.ProductCode = reader["ProductCode"].ToString();
                            IncidentList.Add(Incident);
                        }
                    }
                }  
            }
            return IncidentList;
        }

        public List<Incident> GETOpenIncidentsForTechnicianID(Technician technician) {
            List<Incident> IncidentList = new List<Incident>();
            string selectStatement =
                "SELECT t1.[ProductCode]" +
                ", t1.CustomerID, t1.Description, t4.Name AS ProductName" +
                ", FORMAT([DateOpened],'MM/dd/yyyy') as 'DateOpened'" +
                ",t2.Name AS Customer" +
                ",t3.Name AS Technician" +
                ",[Title] FROM[TechSupport].[dbo].[Incidents] " +
                "t1 LEFT JOIN[TechSupport].[dbo].[Customers]" +
                " t2 ON t1.CustomerID = t2.CustomerID" +
                " LEFT JOIN[TechSupport].[dbo].[Technicians]" +
                " t3 ON t1.TechID = t3.TechID " +
                " LEFT JOIN[TechSupport].[dbo].[Products]" +
                " t4 ON t1.ProductCode = t4.ProductCode " +
                "WHERE [DateClosed] IS NUll AND" +
                " t1.TechID = @TechID";


            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@TechID", technician.TechID);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Incident Incident = new Incident();
                            Incident.CustomerID = (int)reader["CustomerID"];
                            Incident.Title = reader["Title"].ToString();
                            Incident.Description = reader["Description"].ToString();
                            Incident.TechnicianName = reader["Technician"].ToString();
                            Incident.CustomerName = reader["Customer"].ToString();
                            Incident.DateOpened = reader["DateOpened"].ToString();
                            Incident.ProductCode = reader["ProductCode"].ToString();
                            Incident.ProductName = reader["ProductName"].ToString();
                            IncidentList.Add(Incident);
                        }
                    }
                }
            }
            return IncidentList;
        }

        /// <summary>
        /// This method fethces the customer name and the product names
        /// of those customers who have registered their products
        /// </summary>
        /// <returns>a dictionary of Incidents</returns>
        public Dictionary<string, List<string>> GETRegisteredDBCustomersWithProducts()
        {
            Dictionary<string, List<string>> RegisteredCustomerAndProductsList = new Dictionary<string, List<string>>();

            string selectStatement = "SELECT " +
                "DISTINCT t2.Name AS customerName," +
                " t3.[Name] AS productName " +
                "FROM[TechSupport].[dbo].[Registrations] t1 " +
                "LEFT JOIN[TechSupport].[dbo].[Customers] t2 " +
                " ON t1.CustomerID = t2.CustomerID" +
                " LEFT JOIN[TechSupport].[dbo].[Products] t3" +
                " ON t1.ProductCode = t3.ProductCode" +
                " ORDER BY t2.Name;";

            string CurrentName = null;
            List<string> productList = new List<string>();

            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string NewName = reader["customerName"].ToString();

                            if (NewName != CurrentName)
                            {
                                if (!String.IsNullOrEmpty(CurrentName))
                                {
                                    RegisteredCustomerAndProductsList.Add(CurrentName, new List<string>(productList));
                                }
                                CurrentName = NewName;
                                productList.Clear();
                            }
                            productList.Add(reader["productName"].ToString());
                        }
                    }
                }
            }
            return RegisteredCustomerAndProductsList;
        }

        /// <summary>
        /// method to add an incident to database using parameterized queries
        /// </summary>
        /// <param name="incident">is the incident to be added</param>
        internal void AddIncidentToDB(Incident incident)
        {
            string insertStatement =
                "INSERT INTO Incidents(Title,DateOpened,Description,CustomerID,ProductCode) " +
                "VALUES(@IncidentTitle, @IncidentDate, @Description, (SELECT DISTINCT[CustomerID] " +
                "FROM[TechSupport].[dbo].[Customers] " +
                "WHERE Name = @CustomerName),(SELECT DISTINCT[ProductCode] " +
                "FROM[TechSupport].[dbo].[Products] " +
                "WHERE Name = @ProductName)); ";


            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                {
                    insertCommand.Parameters.AddWithValue("@CustomerName",incident.CustomerName);
                    insertCommand.Parameters.AddWithValue("@ProductName", incident.ProductName);
                    insertCommand.Parameters.AddWithValue("@IncidentDate", incident.DateOpened);
                    if(incident.Title == "") {
                        insertCommand.Parameters.AddWithValue("@IncidentTitle", DBNull.Value); 
                            }
                    else {
                        insertCommand.Parameters.AddWithValue("@IncidentTitle", incident.Title);
                            }
                    if (incident.Description == "")
                    {
                        insertCommand.Parameters.AddWithValue("@Description", DBNull.Value);
                    }
                    else
                    {
                        insertCommand.Parameters.AddWithValue("@Description", incident.Description);
                    }

                    insertCommand.ExecuteNonQuery();
                    
                }

                connection.Close();
            }

         
        }


        /// <summary>
        /// method to get an incident from DB
        /// based on incidentID
        /// </summary>
        /// <param name="incident">is the incident to be added</param>
        internal Incident getIncidentFromDBbyID(Incident incident)
        {
            Incident newIncident = new Incident();
            string selectStatement =
              "SELECT [IncidentID]" +
                ",[ProductCode]" +
                ",FORMAT([DateOpened],'MM/dd/yyyy') as 'DateOpened'" +
                ",FORMAT([DateClosed],'MM/dd/yyyy') as 'DateClosed'" +
                ",[Title]" +
                ",[Description]" +
                ",t2.Name AS CustomerName," +
                "t3.Name AS TechnicianName" +
                " FROM[TechSupport].[dbo].[Incidents] as t1" +
                " LEFT JOIN[TechSupport].[dbo].[Customers] t2 ON t1.CustomerID = t2.CustomerID" +
                " LEFT JOIN[TechSupport].[dbo].[Technicians] t3 ON t1.TechID = t3.TechID" +
              " WHERE IncidentID = @IncidentID;";


            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    selectCommand.Parameters.AddWithValue("@IncidentID", incident.IncidentID);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            newIncident.IncidentID = (int)reader["IncidentID"];
                            newIncident.Title = reader["Title"].ToString();
                            newIncident.Description = reader["Description"].ToString();
                            newIncident.TechnicianName = reader["TechnicianName"].ToString();
                            newIncident.CustomerName = reader["CustomerName"].ToString();
                            newIncident.DateOpened = reader["DateOpened"].ToString();
                            newIncident.ProductCode = reader["ProductCode"].ToString();
                            newIncident.DateClosed = reader["DateClosed"].ToString();
                        }
                    }
                }
            }
            return newIncident;
        }
        

        /// <summary>
        /// Add an incident to database based on incident ID
        /// </summary>
        /// <param name="incident">is the incident to be added</param>
        internal void updateIncidentInDB(Incident incident, Incident retrivedIncident)
        {
            string updateStatement =
              "UPDATE Incidents SET " +
                "DateClosed = @DateClosed, " +
                "Description = @Description, " +
                "TechID = (SELECT DISTINCT [TechID] " +
                "FROM[TechSupport].[dbo].[Technicians] " +
                "WHERE Name = @TechName) " +
              "WHERE IncidentID = @IncidentID AND Description LIKE @OriginalDescription" +
              " AND DateClosed IS NULL;";


            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand updateCommand = new SqlCommand(updateStatement, connection))
                {
                    updateCommand.Parameters.AddWithValue("@IncidentID", incident.IncidentID);
                    if (incident.Description == null)
                    {
                        updateCommand.Parameters.AddWithValue("@Description", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@Description", incident.Description);
                    }
                    if (retrivedIncident.Description == null)
                    {
                        updateCommand.Parameters.AddWithValue("@OriginalDescription", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@OriginalDescription", retrivedIncident.Description);
                    }
                    if (retrivedIncident.DateClosed == null)
                    {
                        updateCommand.Parameters.AddWithValue("@OriginalDateClosed", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@OriginalDateClosed", retrivedIncident.DateClosed);
                    }

                    if (incident.TechnicianName == "")
                    {
                        updateCommand.Parameters.AddWithValue("@TechName", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@TechName", incident.TechnicianName);
                    }
                    if (String.IsNullOrEmpty(incident.DateClosed))
                    {
                        updateCommand.Parameters.AddWithValue("@DateClosed", DBNull.Value);
                    }
                    else
                    {
                        updateCommand.Parameters.AddWithValue("@DateClosed", incident.DateClosed);
                    }

                    updateCommand.ExecuteNonQuery() ;

                }

                connection.Close();
            }


        }

        /// <summary>
        /// This method fethces the technicians names
        /// </summary>
        /// <returns>a list of technician names</returns>
        public List<string> GETTechnicianListFromDB()
        {
            List<string> TechnicianList = new List<string>();
            string selectStatement =
                "SELECT DISTINCT [Name] " +
                " FROM[TechSupport].[dbo].[Technicians]";


            using (SqlConnection connection = DBConnection.GetConnection())
            {
                connection.Open();

                using (SqlCommand selectCommand = new SqlCommand(selectStatement, connection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           TechnicianList.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            return TechnicianList;
        }





    }
}
