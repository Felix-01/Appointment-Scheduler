using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MyAppointmentManager
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            string connectionString = "Data Source=.;Initial Catalog=MyAppointmentDb;Integrated Security=True;Pooling=False";
            string query = "Select * From [Login] Where UserName = '" + tbxUname.Text + "' And [Password] = '"+tbxPword.Text+"'";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();

            try
            {
                count += da.Fill(dt);

                if (count == 1)
                {
                    ClientDetails clientDetails = new ClientDetails();
                    clientDetails.Show();
                    this.Hide();
                }
                else
                {
                    
                    MessageBox.Show("Invalid Credentials");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }     
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NewUser newUser = new NewUser();
            newUser.Show();

            Login login = new Login();
            login.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            tbxUname.Focus();
        }
    }
}
