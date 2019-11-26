using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace OO_Challenge_WebApi.Controllers
{
    public class NotBorrowedController : ApiController
    {
        // GET: api/NotBorrowed
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


                query = "select * from Books where borrower is null ";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add("{ISBN: " + rdr.GetValue(0)
                                 + ", title: " + rdr.GetValue(1) + "}");
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

        // GET: api/NotBorrowed/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NotBorrowed
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NotBorrowed/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NotBorrowed/5
        public void Delete(int id)
        {
        }
    }
}
