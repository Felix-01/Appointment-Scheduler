using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyAppointmentManager
{
    public partial class ClientDetails : Form
    {
        public ClientDetails()
        {
            InitializeComponent();
        }

        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            int count = 0;
            string connectionString = "Data Source=.;Initial Catalog=MyAppointmentDb;Integrated Security=True;Pooling=False";
            string query = "Select * From [User] Where PPSNo = '" + tbxPPS.Text + "'";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            try
            {
                count += da.Fill(dt);
                                
                if (count == 0)
                {
                    MessageBox.Show("No Booking Found");
                    tbxPPS.Clear();
                    tbxPPS.Focus();
                }
                else
                {
                    dgvClients.DataSource = dt;
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ClientDetails_Load(object sender, EventArgs e)
        {
            tbxPPS.Focus();
            dateTimePicker.Value = DateTime.Now;
        }

        private void btnByDate_Click(object sender, EventArgs e)
        {
            int count = 0;
            string connectionString = "Data Source=.;Initial Catalog=MyAppointmentDb;Integrated Security=True;Pooling=False";
            string query = "Select * From [User] Where Date = '" + dateTimePicker.Value.ToString("yyyy-MM-dd") + "'";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            try
            {
                count += da.Fill(dt);

                if (count == 0)
                {
                    MessageBox.Show("No Booking Found");
                }
                else
                {
                    dgvClients.DataSource = dt;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
