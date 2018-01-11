using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAppointmentManager
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string connectionString = "Data Source=.;Initial Catalog=MyAppointmentDb;Integrated Security=True;Pooling=False";
            string query = "Insert Into [Login] Values('" + tbxUName.Text + "', '" + tbxPword2.Text + "')";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            if (tbxPword2.Text == tbxConPword.Text)
            {
                count += cmd.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Password and Confirm Password do not match");
            }
            if(count == 1)
            {
                ClientDetails clientDetails = new ClientDetails();
                clientDetails.Show();
                this.Close();
            }
        }
    }
}
