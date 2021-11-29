using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace McLaughlinUniversity
{
    /// <summary>
    /// Interaction logic for TargetsWindow.xaml
    /// </summary>
    public partial class TargetsWindow : Window
    {
        public TargetsWindow()
        {
            InitializeComponent();
            PopulateTargetGrid();
        }

        private void PopulateTargetGrid()
        {
            string connectString = DataAccess.GetConnectionString();
            SqlConnection connection = new SqlConnection(connectString);

            SqlCommand command = new SqlCommand("SELECT targetID, yearNO, firstQuarterTarget, secondQuarterTarget, thirdQuarterTarget, fourthQuarterTarget FROM tblTargets", connection);

            try
            {
                connection.Open();

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                DataTable data = new DataTable("Targets");
                dataAdapter.Fill(data);

                dgTargets.ItemsSource = data.DefaultView;

            }

            catch (Exception ex)
            {
                MessageBox.Show("There was an error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
