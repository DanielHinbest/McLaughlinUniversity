using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;

namespace McLaughlinUniversity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            User user = new User();
            if (txtUserID.Text != string.Empty && txtPassword.Password != string.Empty)
            {
                user = DataAccess.GetUser(txtUserID.Text, txtPassword.Password);
                if (user.UserID != null && user.Password != null)
                {
                    DashboardWindow dashboardWindow = new DashboardWindow();
                    dashboardWindow.Show();
                    this.Hide();
                }
                else
                {
                    lblErrors.Visibility = Visibility.Visible;
                    lblErrors.Content = "Invalid username or password";
                }
            }
            else
            {
                lblErrors.Visibility = Visibility.Visible;
                lblErrors.Content = "Please enter a username and password";
            }
            //MessageBox.Show(user.UserID, user.Password);           
            
        }
    }
}

