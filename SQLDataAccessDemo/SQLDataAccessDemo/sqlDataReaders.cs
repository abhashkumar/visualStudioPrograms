using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;


/*
 
DataReader is used to read the data from the database and it is a read and forward only connection oriented architecture during fetch the data from database. 
DataReader will fetch the data very fast when compared with dataset. Generally, we will use ExecuteReader object to bind data to datareader.


DataSet is a disconnected orient architecture that means there is no need of active connections during work with datasets and it is a collection of DataTables and relations between tables. 
It is used to hold multiple tables with data. You can select data form tables, create views based on table and ask child rows over relations. 
Also DataSet provides you with rich features like saving data as XML and loading XML data. 
It is used to hold multiple tables with data. You can select data form tables, create views based on table and ask child rows over relations. 

DataAdapter will acts as a Bridge between DataSet and database. 
This dataadapter object is used to read the data from database and bind that data to dataset.

DataTable represents a single table in the database. It has rows and columns. 
There is no much difference between dataset and datatable, dataset is simply the collection of datatables.

 */


namespace SQLDataAccessDemo
{
    public class sqlDataReaders
    {
        public void DBOperation(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from dbo.People", connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        string id = reader.GetString(0);
                        string FirstName = reader.GetString(1);
                        string LastName = reader.GetString(2);
                        string EmailAddress = reader.GetString(3);
                        string PhoneNumber = reader.GetString(4);
                        Console.WriteLine($"{id} {FirstName} {LastName} {EmailAddress} {PhoneNumber}");
                    }
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter  adap = new SqlDataAdapter("Select * from dbo.People", connection))
                {
                    connection.Open();
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adap = new SqlDataAdapter("Select * from dbo.People", connection))
                {
                    connection.Open();
                    DataSet ds = new DataSet();
                    adap.Fill(ds);
                    // Data reader works on connected data source, but dataset or data table does not need and active data connection
                    // SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from customers; select * from orders", connection);
                    // SqlDataAdapter can take multiple queries at the same time and if you fill this in dataset, the dataset will have 2 tables
                    /*
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                    }    
                     */
                    foreach (DataRow row in ds.Tables["People"].Rows)
                    {

                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("Insert into dbo.People values(@id, @FirstName, @LastName, @EmailAddress, @PhoneNumber)", connection))
                {
                    /*
                    cmd.Parameters.AddWithValue("@id", "20");
                    cmd.Parameters.AddWithValue("@FirstName", "Abhash");
                    cmd.Parameters.AddWithValue("@LastName", "Kumar");
                    cmd.Parameters.AddWithValue("@EmailAddress", "abhashmaddi@gmail.com");
                    cmd.Parameters.AddWithValue("@PhoneNumber", "1234567890");
                    */
                    
                    /*
                    cmd.Parameters.Add("@ID", SqlDbType.NVarChar).Value = "21";
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = "Abhash";
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = "Kumar";
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = "abhashmaddi@gmail.com";
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = "1234567890";
                    
                    int effectedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine(effectedRows);
                    */
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                /*
                using (SqlCommand cmd = new SqlCommand("spPeople_Insert", connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@iD", SqlDbType.NVarChar).Value = "31";
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = "Abhash";
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = "Kumar";
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar).Value = "abhashmaddi@gmail.com";
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = "1234567890";

                    int effectedRows = cmd.ExecuteNonQuery();
                    Console.WriteLine(effectedRows);
                }
                */
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                /*
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(@"Update dbo.People set LastName = @LastName where FirstName = @FirstName", connection, transaction);
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = "Daddy";
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = "Abhash";
                    int effectedRow = cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
                finally
                {
                    connection.Close();
                }
                */
            }
            using(IDbConnection db = new SqlConnection(connectionString))
            {
                db.Open();
                List<Person> personList = (List<Person>)db.Query<Person>("Select * from dbo.People");
                foreach(Person p in personList)
                {
                    Console.WriteLine($"{p.ID} {p.FirstName} {p.LastName} {p.EmailAddress}, {p.PhoneNumber}");
                }
            }
        }
    }
}
