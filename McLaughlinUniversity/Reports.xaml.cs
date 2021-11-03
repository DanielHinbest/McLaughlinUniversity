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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        string title = "McLaughlin University";
        public Reports()
        {
            InitializeComponent();
            lblTitle.Content = title;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Control individualCampusTargets = new IndividualCampusTargetsReport();
            Control donorContributionProjections = new DonorContributionProjectionsReport();
            Control donorTypeTargets = new DonorTypeTargetsReport();
            Control committeeMemberAssignmentAndTargets = new CommitteeMemberAssignmentsAndTargetsReport();
            Control contributionsList = new ContributionsList();
            Control donorContributionReport = new DonorContributionReport();
            Control committeePerformanceReport = new CommitteePerformanceReport();
            Control contributionsByCampus = new ContributionsByCampus();
            Control contributionsByDonorCategory = new ContributionsByDonorCategory();
            Control contributionsToProgramsByDonorCategory = new ContributionsToProgramsByDonorCategory();
            ListView list = e.Source as ListView;

            if (list != null)
            {
                ReportPanel.Children.Clear();

                if (list.SelectedItem.Equals(IndividualCampusTargets))
                {
                    lblTitle.Content = title + " - Individual Campus Targets";
                    ReportPanel.Children.Add(individualCampusTargets);
                }
                else if (list.SelectedItem.Equals(DonorContributionProjections))
                {
                    lblTitle.Content = title + " - Donor Contributions Projections";
                    ReportPanel.Children.Add(donorContributionProjections);
                }
                else if (list.SelectedItem.Equals(DonorTypeTargets))
                {
                    lblTitle.Content = title + " - Donor Type Targets";
                    ReportPanel.Children.Add(donorTypeTargets);
                }
                else if (list.SelectedValue.Equals(CommitteeMemberAssignmentsandTargets))
                {
                    lblTitle.Content = title + " - Committee Member Assignments And Targets";
                    ReportPanel.Children.Add(committeeMemberAssignmentAndTargets);
                }
                else if (list.SelectedItem.Equals(ContributionsList))
                {
                    lblTitle.Content = title + " - Contributions List";
                    ReportPanel.Children.Add(contributionsList);
                }
                else if (list.SelectedItem.Equals(DonorContributionReport))
                {
                    lblTitle.Content = title + " - Donor Contribution Report";
                    ReportPanel.Children.Add(donorContributionReport);
                }
                else if (list.SelectedItem.Equals(CommitteePerformanceReport))
                {
                    lblTitle.Content = title + " - Committee Performance Report";
                    ReportPanel.Children.Add(committeePerformanceReport);
                }
                else if (list.SelectedItem.Equals(ContributionsByCampus))
                {
                    lblTitle.Content = title + " - Contributions By Campus";
                    ReportPanel.Children.Add(contributionsByCampus);
                }
                else if (list.SelectedItem.Equals(ContributionsByDonorCategory))
                {
                    lblTitle.Content = title + " - Contributions By Donor Category";
                    ReportPanel.Children.Add(contributionsByDonorCategory);
                }
                else if (list.SelectedItem.Equals(ContributionsToProgramsByDonorCategory))
                {
                    lblTitle.Content = title + " - Contributions To Programs By Donor Category";
                    ReportPanel.Children.Add(contributionsToProgramsByDonorCategory);
                }
            }
        }
    }
}
