using BUS;
using BUS.Service; // Ensure you have access to your BUS services
using DTO.Entities; // Ensure you have access to your DTOs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Control
{
    public partial class FlightControl : UserControl
    {
        private CityBUS _cityBus; // Declare a CityBUS instance
        private FlightBUS _flightBus; // Declare a FlightBUS instance

        public FlightControl()
        {
            InitializeComponent();
            _cityBus = new CityBUS(); // Initialize CityBUS
            _flightBus = new FlightBUS(); // Initialize FlightBUS

            // Set default header height
            dgvList.ColumnHeadersHeight = 20; // Set header height to 20 pixels

            LoadAirports(); // Load the cities into the ComboBox

            // Subscribe to the SelectedIndexChanged event of cmbCity
            cmbCity.SelectedIndexChanged += CmbCity_SelectedIndexChanged;
        }

        private void LoadAirports()
        {
            try
            {
                // Get all cities from the CityBUS
                var cities = _cityBus.GetAllCities();

                // Bind the data to cmbCity
                cmbCity.DataSource = cities.ToList(); // Convert to list if needed
                cmbCity.DisplayMember = "CityName"; // Property to display
                cmbCity.ValueMember = "CityId"; // Property for value

                // Set the maximum height of the dropdown
                cmbCity.DropDownHeight = 200; // Set height as per your requirement
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading cities: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected city ID
            string selectedCityId = cmbCity.SelectedValue.ToString();
            LoadFlightsByCity(selectedCityId); // Load flights for the selected city
        }

        private void LoadFlightsByCity(string cityId)
        {
            try
            {
                // Get all flights that match the selected city ID
                var flights = _flightBus.GetFlightsByCityId(cityId).ToList(); // Use the GetFlightsByCityId method

                // Clear existing columns
                dgvList.Columns.Clear();

                // Set AutoGenerateColumns to false
                dgvList.AutoGenerateColumns = false;

                // Create columns
                dgvList.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Điểm khởi hành",
                    DataPropertyName = "OriginAP", // Change to the actual property in your Flight class
                    Width = 120 // Adjust width as needed
                });
                dgvList.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Sân bay đi",
                    DataPropertyName = "OriginAP", // Change to the actual property in your Flight class
                    Width = 120 // Adjust width as needed
                });
                dgvList.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Điểm kết thúc",
                    DataPropertyName = "DestinationAP", // Change to the actual property in your Flight class
                    Width = 120 // Adjust width as needed
                });
                dgvList.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Sân bay đến",
                    DataPropertyName = "DestinationAP", // Change to the actual property in your Flight class
                    Width = 120 // Adjust width as needed
                });
                dgvList.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Thời gian",
                    DataPropertyName = "Duration", // Change to the actual property in your Flight class
                    Width = 80 // Adjust width as needed
                });
                dgvList.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = "Transit",
                    DataPropertyName = "Transit", // Change to the actual property in your Flight class
                    Width = 80 // Adjust width as needed
                });

                // Bind flights data to the DataGridView
                dgvList.DataSource = flights; // Bind the data source
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading flights: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelFlightList_Paint(object sender, PaintEventArgs e)
        {
            // Your painting code here
        }
    }
}
