using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Assessment
{
    public partial class Form1 : Form
    {
        Database myDatabase = new Database();
        public Form1()
        {
            InitializeComponent();
            loadDB();
        }

        public void loadDB()
        {
            DisplayDGVCustomer();
            DisplayDGVMovies();
            DisplayDGVRentals();
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
    }
}
