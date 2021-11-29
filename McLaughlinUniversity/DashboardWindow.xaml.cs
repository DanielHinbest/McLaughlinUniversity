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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnViewDonors_Click(object sender, RoutedEventArgs e)
        {
            DonorWindow donorWindow = new DonorWindow();
            donorWindow.Show();
        }

        private void btnViewPrograms_Click(object sender, RoutedEventArgs e)
        {
            ProgramWindow programWindow = new ProgramWindow();
            programWindow.Show();
        }

        private void btnAddNewDonor_Click(object sender, RoutedEventArgs e)
        {
            AddDonorWindow addDonorWindow = new AddDonorWindow();
            addDonorWindow.Show();

        }

        private void btnViewTargets_Click(object sender, RoutedEventArgs e)
        {
            TargetsWindow targetsWindow = new TargetsWindow();
            targetsWindow.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            SearchTransactionsWindow searchTransactionsWindow = new SearchTransactionsWindow();
            searchTransactionsWindow.Show();
        }

        private void btnTransactionHistory_Click(object sender, RoutedEventArgs e)
        {
            TransactionsHistory transactionsHistory = new TransactionsHistory();
            transactionsHistory.Show();
        }
    }
}
