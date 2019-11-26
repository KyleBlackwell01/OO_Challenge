using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace OO_Challenge_WebApi.Controllers
{
    public class BorrowerController : ApiController
    {
        // GET: api/Borrower
        public IEnumerable<string> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<String> output = new List<string>();

            try
            {
                conn.Open();


                query = "select * from Borrower";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add("{PK: " + rdr.GetValue(0)
                                 + ", surname: " + rdr.GetValue(1) + ""
                                 + ", firstname: " + rdr.GetValue(2) + ""
                                 + ", DOB: " + rdr.GetValue(2) + "}");
                }

            }
            catch (Exception e)
            {
                output.Clear();
                output.Add(e.Message);

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;
        }

        // GET: api/Borrower/5
        public string Get(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            String output = "";

            try
            {
                conn.Open();


                query = "select * from Borrower where id =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = output + "{PK: " + rdr.GetValue(0)
                                 + ", surname: " + rdr.GetValue(1) + ""
                                 + ", firstname: " + rdr.GetValue(2) + ""
                                 + ", DOB: " + rdr.GetValue(3) + "}";
                }

            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;

            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;
        }

        // POST: api/Borrower
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Borrower/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Borrower/5
        public void Delete(int id)
        {
        }
    }
}
