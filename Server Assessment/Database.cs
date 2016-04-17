using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Assessment
{
    public class Database
    {
        //Connection and Command, and an Adapter.
        public SqlConnection Connection = new SqlConnection();
        private SqlCommand Command = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();

        public string IssueMovieProcedure = "dbo.IssueMovie";
        public string ReturnMovieProcedure = "dbo.ReturnMovie";
        public string MostPopluarMovieView = "select * from dbo.TimesRented ORDER BY [Times Rented] DESC";
        public int copies;

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
            using (da = new SqlDataAdapter("select MovieID, Rating, Title, Year, Copies, Plot, Genre from Movies", Connection))
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
            using (da = new SqlDataAdapter("select * from Rented  ORDER BY [RMID]", Connection))
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

        public DataTable FillDGVBiggestRenterWithBR()
        {
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from BiggestRenter ORDER BY [Times Customer Has Borrowed] DESC", Connection))
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

        public DataTable FillDGVPopluarMovieWithPM()
        {
            DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from dbo.TimesRented ORDER BY[Times Rented] DESC", Connection))
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

        public string AddingCustomer(string[] AlltextBoxes)
        {
            string AddCustomor =
                "INSERT INTO Customer (Firstname, LastName, Address, Phone) VALUES (@Firstname, @LastName, @Address, @Phone)";
            using (SqlCommand newdata = new SqlCommand(AddCustomor, Connection))
            {

                newdata.Parameters.AddWithValue("@FirstName", AlltextBoxes[1]);
                newdata.Parameters.AddWithValue("@LastName", AlltextBoxes[2]);
                newdata.Parameters.AddWithValue("@Address", AlltextBoxes[3]);
                newdata.Parameters.AddWithValue("@Phone", AlltextBoxes[4]);
                
                Connection.Open(); // open a connection to the datatbase
                newdata.ExecuteNonQuery(); // Run the Query
                Connection.Close();
                return AlltextBoxes[1] + " " + AlltextBoxes[2] + " has been Inserted";
            }
        }

        public string AddingMovie(string[] AlltextBoxes)
        {
            string AddMovie =
                "INSERT INTO Movies (Rating, Title, Year, Copies, Plot, Genre) VALUES (@Rating, @Title, @Year, @Copies, @Plot, @Genre)";
            using (SqlCommand newdata = new SqlCommand(AddMovie, Connection))
            {

                newdata.Parameters.AddWithValue("@Rating", AlltextBoxes[1]);
                newdata.Parameters.AddWithValue("@Title", AlltextBoxes[2]);
                newdata.Parameters.AddWithValue("@Year", AlltextBoxes[3]);
                newdata.Parameters.AddWithValue("@Copies", AlltextBoxes[4]);
                newdata.Parameters.AddWithValue("@Plot", AlltextBoxes[5]);
                newdata.Parameters.AddWithValue("@Genre", AlltextBoxes[6]);
                
                Connection.Open(); // open a connection to the datatbase
                newdata.ExecuteNonQuery(); // Run the Query
                Connection.Close();
                return AlltextBoxes[2] + " " + AlltextBoxes[3] + " has been Inserted";
            }
        }

        public bool TestConenctionString()
          
        {
            try
            {
                string connectionString =
                    @"Data Source = TIM\SQLEXPRESS; Initial Catalog = VBMoviesFullData; Integrated Security = True; Connect Timeout = 15;
                Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

                Connection.ConnectionString = connectionString;
                Command.Connection = Connection;

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool TestFillDGVCustomerWithCustomer()
        {
            try
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
                
                return true;
            }

    catch (Exception)
            { 

            return false;
            }
        }

        public bool TestFillDGVMoviesWithMovies()
        {
            try
            {

                DataTable dt = new DataTable();
                using (da = new SqlDataAdapter("select MovieID, Rating, Title, Year, Copies, Plot, Genre from Movies", Connection))
                {
                    //connect in to the DB and get the SQL
                    Connection.Open();
                    //Open a connection to the DB
                    da.Fill(dt);
                    //fill the datatable from the SQL
                    Connection.Close(); //close the connection
                }

                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }

        public bool TestFillDGVRentalsWithRentals()
        {
            try
            {

                DataTable dt = new DataTable();
                using (da = new SqlDataAdapter("select * from Rented", Connection))
                {
                    //connect in to the DB and get the SQL
                    Connection.Open();
                    //Open a connection to the DB
                    da.Fill(dt);
                    //fill the datatable from the SQL
                    Connection.Close(); //close the connection
                }

                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }
        public bool TestFillDGVBRWithBR()
        {
            try
            {

                DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from Biggest Renter", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //Open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }
                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }

        public bool TestFillDGVPMWithPM()
        {
            try
            {

                DataTable dt = new DataTable();
            using (da = new SqlDataAdapter("select * from dbo.TimesRented ORDER BY[Times Rented] DESC", Connection))
            {
                //connect in to the DB and get the SQL
                Connection.Open();
                //Open a connection to the DB
                da.Fill(dt);
                //fill the datatable from the SQL
                Connection.Close(); //close the connection
            }
                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }

    }
}
