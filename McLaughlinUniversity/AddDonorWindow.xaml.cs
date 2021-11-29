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
    /// Interaction logic for AddDonor.xaml
    /// </summary>
    public partial class AddDonorWindow : Window
    {
        public AddDonorWindow()
        {
            InitializeComponent();
            setDeafults();
        }


        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            setDeafults();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            int[] donorTypeArray = {900001, 900002, 900003};
            try
            {
                Donor newDonor;
                if ((bool)rdbIndividualType.IsChecked)
                {
                    newDonor = new Donor(txtFirstName.Text, txtLastName.Text, txtEmailAddress.Text, txtPhoneNo.Text, donorTypeArray[0]);

                }
                else if((bool)rdbCorporationType.IsChecked)
                {
                    newDonor = new Donor(txtFirstName.Text, txtLastName.Text, txtEmailAddress.Text, txtPhoneNo.Text, txtCorporationName.Text, donorTypeArray[1]);

                }
                else
                {
                    newDonor = new Donor(txtFirstName.Text, txtLastName.Text, txtEmailAddress.Text, txtPhoneNo.Text, txtFoundationName.Text, donorTypeArray[2]);
                }

                MessageBox.Show(newDonor.Show());
                setDeafults();
            }
            catch (Exception ex)
            {
                MessageBox.Show("You suck at coding");
            }

           
        }

        private void setDeafults()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmailAddress.Clear();
            txtPhoneNo.Clear();
            txtCorporationName.Clear();
            txtFoundationName.Clear();

            txtFirstName.Focus();

            txtCorporationName.Visibility = Visibility.Hidden;
            txtFoundationName.Visibility = Visibility.Hidden;
            lblCorporationName.Visibility = Visibility.Hidden;
            lblFoundationName.Visibility = Visibility.Hidden;

            rdbIndividualType.IsChecked = true;
        }

        private void rdbFoundationType_Checked(object sender, RoutedEventArgs e)
        {
            lblFoundationName.Visibility = Visibility.Visible;
            txtFoundationName.Visibility = Visibility.Visible;
            lblCorporationName.Visibility = Visibility.Hidden;
            txtCorporationName.Visibility = Visibility.Hidden;
        }

        private void rdbCorporationType_Checked(object sender, RoutedEventArgs e)
        {
            lblFoundationName.Visibility = Visibility.Hidden;
            txtFoundationName.Visibility = Visibility.Hidden;
            lblCorporationName.Visibility = Visibility.Visible;
            txtCorporationName.Visibility = Visibility.Visible;
        }

        private void rdbIndividualType_Checked(object sender, RoutedEventArgs e)
        {
            txtCorporationName.Visibility = Visibility.Hidden;
            txtFoundationName.Visibility = Visibility.Hidden;
            lblCorporationName.Visibility = Visibility.Hidden;
            lblFoundationName.Visibility = Visibility.Hidden;
        }
    }
}
