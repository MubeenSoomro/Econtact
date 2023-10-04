using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace econtact.econtactClasses
{
    internal class contactClass
    {
        //getter setter properties
        //Acts as data carrier in our Application

        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ContactNo { get; set; }
        public string Gender { get; set; }

        public string Address { get; set; }



        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        //selecting data from database
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM econtacts";

                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }



        //inserting data into database

        public bool Insert(contactClass c)
        {
            //creating default retun type
            bool isSuccess = false;

            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO contacts (cid, fname, lname, cno, gender, adrs) VALUES (@cid, @fname, @lname, @cno, @gender, @adrs)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                //parameters
                cmd.Parameters.AddWithValue("@cid", c.ContactID);
                cmd.Parameters.AddWithValue("@fname", c.FirstName);
                cmd.Parameters.AddWithValue("@lname", c.LastName);
                cmd.Parameters.AddWithValue("@cno", c.ContactNo);
                cmd.Parameters.AddWithValue("@gender", c.Gender);
                cmd.Parameters.AddWithValue("@adrs", c.Address);


                //open conn
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if query run
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally {
                conn.Close();
            }









            return isSuccess;
        }


        //default return

        //        public bool Update(contactClass c) { 


        //        bool isSuccess = false;

        //        SqlConnection con = new SqlConnection(myconnstrng);
        //        try
        //        {
        //        string sql= ""
        //        }

        //        catch(Exception ex)
        //            {

        //}

//    }


    }
}
