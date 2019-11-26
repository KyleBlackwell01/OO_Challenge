using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace OO_Challenge_WebApi.Controllers
{
    public class BorrowedController : ApiController
    {
        // GET: api/Borrowed
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


                query = "select * from Books where borrower is not null ";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add("{ISBN: " + rdr.GetValue(0)
                                 + ", title: " + rdr.GetValue(1) + ""
                                 + ", borrower: " + rdr.GetValue(3) + "}");
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

        // GET: api/Borrowed/5
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


                query = "select * from Books where borrower =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = output + ("{ISBN: " + rdr.GetValue(0)
                                 + ", title: " + rdr.GetValue(1) + ""
                                 + ", PK: " + rdr.GetValue(3) + "}");
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

        // POST: api/Borrowed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Borrowed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Borrowed/5
        public void Delete(int id)
        {
        }
    }
}
