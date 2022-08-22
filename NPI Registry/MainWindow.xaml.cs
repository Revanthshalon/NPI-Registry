using CsvHelper;
using NPI_Registry.DTO;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System;

namespace NPI_Registry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GetDetails(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Getting User Details");
            IEnumerable<NPIDTO> NpiList = Tools.CSV.ReadCsv(path);
            ICollection<HCPDTO> HcpDetails = await NPIRegistry.NPIDetails.GetHCPDetailsList(NpiList);
            List<CSVDTO> responses = new();
            string tax;
            foreach(var hcp in HcpDetails)
            {
                tax = string.Empty;
                foreach(var taxo in hcp.HCPDetails[0].Taxonomies)
                {
                    if (taxo.Primary)
                    {
                        tax = taxo.Description;
                    }
                }
                CSVDTO details = new CSVDTO()
                {
                    UserWaveId = hcp.UserWaveID,
                    NPI = hcp.HCPDetails[0].NPI,
                    FirstName = hcp.HCPDetails[0].UserDetails.FirstName,
                    LastName = hcp.HCPDetails[0].UserDetails.LastName,
                    CertificateLastUpdatedDate = hcp.HCPDetails[0].UserDetails.CertificationDate,
                    Taxonomy = tax
                };
                responses.Add(details);
            }

            using (var writer = new StreamWriter(@"C:\Users\ZoomRx\Downloads\HCPDetails.csv"))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(responses);
                }
            }
            MessageBox.Show("Completed");
        }

        private void FileSelect(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "CSV files|*.csv";
            fileDialog.DefaultExt = ".csv";

            Nullable<bool> dialogOk = fileDialog.ShowDialog();

            if (dialogOk == true)
            {
                path = fileDialog.FileName;
                ListViewNPI.ItemsSource = Tools.CSV.ReadCsv(fileDialog.FileName);
            }
        }
    }
}
