using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Assessment
{
    public partial class Form1 : Form
    {
        Database myDatabase = new Database();
        SqlConnection Connection = new SqlConnection();
        private string[] AllTextBoxes;

        public Form1()
        {
            Connection.ConnectionString = myDatabase.Connection.ConnectionString;
            InitializeComponent();
            loadDB();

            //make DataGridViews read only
            DGVCustomers.ReadOnly = true;
            DGVBiggestRenter.ReadOnly = true;
            DGVMovies.ReadOnly = true;
            DGVPopularMovie.ReadOnly = true;
            DGVRentals.ReadOnly = true;

        }

        public void loadDB()
        {
            //Display All DataGridViews
            DisplayDGVCustomer();
            DisplayDGVMovies();
            DisplayDGVRentals();
            DisplayDGVBiggestRenter();
            DisplayDGVMostPopular();
        }

        private void DisplayDGVCustomer()
        {
            //clear out the old data
            DGVCustomers.DataSource = null;
            try
            {
                DGVCustomers.DataSource = myDatabase.FillDGVCustomerWithCustomer();
                //pass the datatable data to the DataGridView
                DGVCustomers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayDGVMovies()
        {
            //clear out the old data
            DGVMovies.DataSource = null;
            try
            {
                DGVMovies.DataSource = myDatabase.FillDGVMoviesWithMovies();
                //pass the datatable data to the DataGridView
                DGVMovies.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayDGVRentals()
        {
            //clear out the old data
            DGVRentals.DataSource = null;
            try
            {
                DGVRentals.DataSource = myDatabase.FillDGVRentalsWithRentals();
                //pass the datatable data to the DataGridView
                DGVRentals.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayDGVBiggestRenter()
        {
            //clear out the old data
            DGVBiggestRenter.DataSource = null;
            try
            {
                DGVBiggestRenter.DataSource = myDatabase.FillDGVBiggestRenterWithBR();
                //pass the datatable data to the DataGridView
                DGVBiggestRenter.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGVCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Send data from DGV Customer to these textboxs on cell click
            int CustID = 0;
            try
            {
                CustID = (int) DGVCustomers.Rows[e.RowIndex].Cells[0].Value;
                txtFN.Text = DGVCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLN.Text = DGVCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtAddress.Text = DGVCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhone.Text = DGVCustomers.Rows[e.RowIndex].Cells[4].Value.ToString();
                lblCustID.Text = CustID.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void DisplayDGVMostPopular()
        {
            //clear out the old data
            DGVPopularMovie.DataSource = null;
            try
            {
                DGVPopularMovie.DataSource = myDatabase.FillDGVPopluarMovieWithPM();
                //pass the datatable data to the DataGridView
                DGVPopularMovie.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DGVMovies_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Send data from DGV Movies to these textboxs on cell click
            try
            {
                lblMovieID.Text = DGVMovies.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtRating.Text = DGVMovies.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTitle.Text = DGVMovies.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtYear.Text = DGVMovies.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtCopies.Text = DGVMovies.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtPlot.Text = DGVMovies.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtGenre.Text = DGVMovies.Rows[e.RowIndex].Cells[6].Value.ToString();
                myDatabase.copies = Convert.ToInt32(txtCopies.Text);
                lblCost.Text = Cost();

            }
            catch (Exception)
            {

            }
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            //If user hasn't entered text in any of the chosen text boxes show message
            if (txtFN.Text == String.Empty || txtLN.Text == String.Empty
                || txtAddress.Text == String.Empty || txtPhone.Text == String.Empty)

            //Show this message
            {
                MessageBox.Show("Please enter all fields to add a customer");
            }
            else
            //Otherwise if user has, add text from textboxes to DGV Customers
            {
                {
                    AllTextBoxes = new string[]
                    {
                        lblCustID.Text, txtFN.Text, txtLN.Text, txtAddress.Text, txtPhone.Text
                    };
                }
                MessageBox.Show(myDatabase.AddingCustomer(AllTextBoxes));

                loadDB();
            }
        }


        private void btnAddMovie_Click(object sender, EventArgs e)
        { 
            //If user hasn't entered text in any of the chosen text boxes

            if (txtRating.Text == String.Empty || txtTitle.Text == String.Empty
                || txtYear.Text == String.Empty || txtPlot.Text == String.Empty || txtGenre.Text == String.Empty)

            //Show this message
            {
                MessageBox.Show("Please enter all fields to add a movie");
            }
            else
            //Otherwise if user has, add text from textboxes to DGV Movies
            {
                AllTextBoxes = new string[]
                {
                    lblMovieID.Text, txtRating.Text, txtTitle.Text, txtYear.Text, txtCopies.Text, txtPlot.Text,
                    txtGenre.Text
                };
                MessageBox.Show(myDatabase.AddingMovie(AllTextBoxes));

                loadDB();
            }

        }

        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            if (lblMovieID.Text == String.Empty)
            {
                MessageBox.Show("Please select Movie ID");
            }
            else
            {

                //Delete movie from database on button click

                Connection.ConnectionString = myDatabase.Connection.ConnectionString;
                string DeleteCommand = "Delete Movies where MovieID = @MovieID";

                using (SqlCommand DeleteData = new SqlCommand(DeleteCommand, Connection))
                {
                    DeleteData.Parameters.AddWithValue("@MovieID", lblMovieID.Text);
                    Connection.Open();
                    DeleteData.ExecuteNonQuery();
                    Connection.Close();
                }
                loadDB();
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (lblCustID.Text == String.Empty)
            {
                MessageBox.Show("Please select Customer ID");
            }
            else
            {
                //Delete customer from database on button click

                Connection.ConnectionString = myDatabase.Connection.ConnectionString;
                string DeleteCommand = "Delete Customer where CustID = @CustID";
                using (SqlCommand DeleteData = new SqlCommand(DeleteCommand, Connection))
                {
                    DeleteData.Parameters.AddWithValue("@CustID", lblCustID.Text);
                    Connection.Open();
                    DeleteData.ExecuteNonQuery();
                    Connection.Close();
                }
                loadDB();
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (lblCustID.Text == String.Empty)
            {
                MessageBox.Show("Please select Customer ID");
            }
            else
            {
                //Update Database with new info in the textboxes

                Connection.ConnectionString = myDatabase.Connection.ConnectionString;
                string updateString =
                    "Update Customer set Firstname=@Firstname, Lastname=@LastName, Address=@Address, Phone=@Phone where CustID=@CustID";
                string connectionString =
                    @"Data Source = TIM\SQLEXPRESS; Initial Catalog = VBMoviesFullData; Integrated Security = True; Connect Timeout = 15;
                Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                Connection.ConnectionString = connectionString;

                using (SqlCommand update = new SqlCommand(updateString, Connection))
                {
                    //create the parameters and pass the data from the textboxes
                    update.Parameters.AddWithValue("@CustID", lblCustID.Text);
                    update.Parameters.AddWithValue("@Firstname", txtFN.Text);
                    update.Parameters.AddWithValue("@Lastname", txtLN.Text);
                    update.Parameters.AddWithValue("@Address", txtAddress.Text);
                    update.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    Connection.Open();
                    update.ExecuteNonQuery();
                    Connection.Close();
                }
                loadDB();
            }
        }

        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            if (lblMovieID.Text == String.Empty)
            {
                MessageBox.Show("Please select Movie ID");
            }
            else
            {
                //Update Movies Database with new info in the textboxes

                Connection.ConnectionString = myDatabase.Connection.ConnectionString;
                string updateString =
                    "Update Movies set Rating=@Rating, Title=@Title, Year=@Year, Copies=@Copies, Plot=@Plot, Genre=@Genre where MovieID=@MovieID";

                string connectionString =
                    @"Data Source = TIM\SQLEXPRESS; Initial Catalog = VBMoviesFullData; Integrated Security = True; Connect Timeout = 15;
                Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

                Connection.ConnectionString = connectionString;
                using (SqlCommand update = new SqlCommand(updateString, Connection))
                {
                    //Create the parameters and pass the data from the textboxes
                    update.Parameters.AddWithValue("@MovieID", lblMovieID.Text);
                    update.Parameters.AddWithValue("@Rating", txtRating.Text);
                    update.Parameters.AddWithValue("@Title", txtTitle.Text);
                    update.Parameters.AddWithValue("@Year", txtYear.Text);
                    update.Parameters.AddWithValue("@Copies", txtCopies.Text);
                    update.Parameters.AddWithValue("@Plot", txtPlot.Text);
                    update.Parameters.AddWithValue("@Genre", txtGenre.Text);
                    Connection.Open();
                    update.ExecuteNonQuery();
                    Connection.Close();
                }
                loadDB();
            }
        }

        private void btnIssueMovie_Click(object sender, EventArgs e)
        {
            if (lblMovieID.Text == String.Empty || lblCustID.Text == String.Empty)
            {
                MessageBox.Show("Please select Customer AND Movie to Issue");
            }
            else
            {
                IssueCount();
            }
        }
private string IssueCount()

        //If Issue button is click and there are no copies of the movie show this message     

        {
                if (myDatabase.copies == 0)
    {
        MessageBox.Show("Movie out of stock");
    }
           //Otherwise minus the copies count by one and Issue the movie

          if (myDatabase.copies > 0)
            {
                myDatabase.copies = (myDatabase.copies - 1);
            }
            Connection.ConnectionString = myDatabase.Connection.ConnectionString;
            using (SqlCommand newdata = new SqlCommand(myDatabase.IssueMovieProcedure, Connection))
            {
                newdata.CommandType = CommandType.StoredProcedure;
                newdata.Parameters.AddWithValue("@MovieIDFK", lblMovieID.Text);
                newdata.Parameters.AddWithValue("@CustIDFK", lblCustID.Text);
                newdata.Parameters.AddWithValue("@DateRented", DateTime.Now);
                newdata.Parameters.AddWithValue("@Copies", myDatabase.copies);

                Connection.Open();
                newdata.ExecuteNonQuery();
                Connection.Close();

            }

            //Update Database
                loadDB();

            return "";
            {
                
            }
       
        }
        private void DGVRentals_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Fill these textboxes on cell click
            try
            {
                lblRMID.Text = DGVRentals.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDateIssued.Text = DGVRentals.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtDateRetuned.Text = DGVRentals.Rows[e.RowIndex].Cells[8].Value.ToString();
                

            }
            catch (Exception)
            {

            }
        }

        private void btnReturnMovie_Click(object sender, EventArgs e)
        {
            if (lblRMID.Text == String.Empty)
            {
                MessageBox.Show("Please select RMID");
            }
            else
            {
                ReturnCount();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear text boxes and labels
            txtDateIssued.Clear();
            txtDateRetuned.Clear();
            lblRMID.Text = "";
            lblCustID.Text = "";
            lblMovieID.Text = "";
            txtAddress.Clear();
            txtFN.Clear();
            txtLN.Clear();
            txtYear.Clear();
            txtTitle.Clear();
            txtRating.Clear();
            txtPlot.Clear();
            txtPhone.Clear();
            txtGenre.Clear();
            lblCost.Text = "";
            txtCopies.Clear();

        }

        private string Cost()
        {
            int MovieYear = (Convert.ToInt32(txtYear.Text));
            int YearNow = Convert.ToInt32(DateTime.Now.Date.Year);
            int YearDifference = YearNow - MovieYear;

              //If movie is over 5 years old from todays date make it $2 otherwise $5
            if (YearDifference > 5)
            {
             return "$2.00";
            }
            

            {
                return "$5.00";
            }
           
        }  
       
        

        private string ReturnCount()
        {
           
                //Add 1 to the movies copy count when movie is returned
                myDatabase.copies = (myDatabase.copies + 1);

                using (SqlCommand newdata = new SqlCommand(myDatabase.ReturnMovieProcedure, Connection))
                {
                    newdata.CommandType = CommandType.StoredProcedure;
                    newdata.Parameters.AddWithValue("@RMID", lblRMID.Text);
                    newdata.Parameters.AddWithValue("@MovieID", lblMovieID.Text);
                    newdata.Parameters.AddWithValue("@DateReturned", DateTime.Now);
                    newdata.Parameters.AddWithValue("@Copies", myDatabase.copies);

                    Connection.Open();
                    newdata.ExecuteNonQuery();
                    Connection.Close();

                }

                loadDB();
                return "";
                
            
        }

        private void txtCopies_KeyPress(object sender, KeyPressEventArgs e)
        {
            //makes it only possible to type numbers in the copies text box
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

       private void DGVMovies_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //If  a movies copies count eqauals zero make it visibly out of stock by making row red (light pink)
            //otherwise it will be a happy in stock green colour :-)

            foreach (DataGridViewRow Myrow in DGVMovies.Rows)
            {            
                if (Convert.ToInt32(Myrow.Cells[4].Value) <= 0 )
                {
                    Myrow.DefaultCellStyle.BackColor = Color.LightPink;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.PaleGreen;
                }
            }
        }
        
        
    }
}