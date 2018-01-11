using MyAppointment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyAppointment.Controllers
{
    public class HomeController : Controller
    {      
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Users()
        {                
            return View();
        }

        [HttpPost]
        public ActionResult Users(User user)
        {
            int count = 0;
            string date = Request.Form["Date"].ToString();
            user.Date = DateTime.Parse(date);

            DAO dao = new DAO();
            int numOfUsers = Count();

            if (ModelState.IsValid) 
            {
                if (numOfUsers < 50)
                {
                    count += dao.Insert(user);

                    if (count == 1)
                    {
                        ViewBag.message = "Success! Your Appointment has been Booked";
                    }
                    else
                    {
                        ViewBag.message = "Error! Appointment could not be booked. Contact the Department";
                    }
                }
                else
                {
                    ViewBag.message = "Day's Quota Exceeded. Choose A Different Date";
                }
            }
            else
            {
                ViewBag.message = "Booking Failed! Invalid Credentials";
            }
            return View("Index");
        }
        public int Count()
        {
            string connectionString = "Data Source=.;Initial Catalog=MyAppointmentDb;Integrated Security=True;Pooling=False";
            string date = Request.Form["Date"].ToString();
            var dateNow = DateTime.Parse(date).ToString("yyyy-MM-dd"); 
            string query = "Select * From [User] Where Date = '" + dateNow + "'";

            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int rowCount = dt.Rows.Count;

            return rowCount;
        }
    }
}