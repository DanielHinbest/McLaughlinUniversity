using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddTransaction.xaml
    /// </summary>
    public partial class AddTransaction : Window
    {
        public AddTransaction()
        {
            InitializeComponent();
        }

        

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Transaction newTransaction;
            newTransaction = new Transaction(Convert.ToDouble(txtAmount.Text), Convert.ToDateTime(dpDate.SelectedDate), Convert.ToInt32(txtDonorID.Text), Convert.ToInt32(txtProgramID.Text), Convert.ToInt32(txtCommitteeID.Text));
            MessageBox.Show(newTransaction.ShowMessage());
            ClearFields();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearFields();

        }

        public void ClearFields()
        {
            txtAmount.Text = string.Empty;
            txtDonorID.Text = string.Empty;
            txtProgramID.Text = string.Empty;
            txtCommitteeID.Text = string.Empty;
        }
    }
}
