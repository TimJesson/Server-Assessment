using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Assessment
{
    class Database
    {
        //Create Connection and Command, and an Adapter.
        private SqlConnection Connection = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();

        public Database()
        {
            string connectionString =
                @"Data Source = TIM\SQLEXPRESS; Initial Catalog = VBMoviesFullData; Integrated Security = True; Connect Timeout = 15;
                Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            Connection.ConnectionString = connectionString;
            Command.Connection = Connection;

        }

        public DataTable FillDGVCustomerWithCustomer()
        {
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from Customer", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //Open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }
            return dt; //pass the datatable data to the DataGridView
        }

        public DataTable FillDGVMoviesWithMovies()
        {
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from Movies", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //Open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }
            return dt; //pass the datatable data to the DataGridView
        }

        public DataTable FillDGVRentalsWithRentals()
        {
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from RentedMovies", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //Open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }
            return dt; //pass the datatable data to the DataGridView
        }
    }

}
