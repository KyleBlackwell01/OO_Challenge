using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using OO_Challenge_WebApi.Models;

namespace OO_Challenge_WebApi.Controllers
{
    public class NotBorrowedController : ApiController
    {
        // GET: api/NotBorrowed
        public IEnumerable<BooksModel> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<BooksModel> output = new List<BooksModel>();

            try
            {
                conn.Open();


                query = "select * from Books where borrower is null ";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new BooksModel(Int32.Parse(rdr["isbn"].ToString()),
                        rdr["title"].ToString()));
                }

            }
            catch (Exception e)
            {
                output.Clear();
                throw e;

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
