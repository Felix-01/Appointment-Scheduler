using System;
using System.Data.SqlClient;


namespace MyAppointment.Models
{
    public class DAO
    {
        string message = "";
        string connectionString = "Data Source=.;Initial Catalog=MyAppointmentDb;Integrated Security=True;Pooling=False";

        public int Insert(User user)
        {
            string query = "Insert Into [User] Values(@PPSNo, @FirstName, @LastName, @Email, @Date, @Comments)";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PPSNo", user.PPSNo);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@Email", user.Email);
            cmd.Parameters.AddWithValue("@Date", user.Date);
            cmd.Parameters.AddWithValue("@Comments", user.Comments);
            
            int count = 0;
            try
            {
                conn.Open();
                count += cmd.ExecuteNonQuery();
                conn.Close();
                                
            }
            catch (Exception ex)
            {

                message = ex.Message;
            }
            return count;
        }
        
    }
}