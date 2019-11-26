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
    public class BookController : ApiController
    {
        // GET: api/Book
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


                query = "select isbn, title from Books";
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
                //output.Add();

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

        // GET: api/Book/5
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
                                 + ", surname: " + rdr.GetValue(1) + "\""
                                 + ", firstname: " + rdr.GetValue(2) + ""
                                 + ", title: " + rdr.GetValue(1) + "}");
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

        // POST: api/Book
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Book/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Book/5
        public void Delete(int id)
        {
        }
    }
}
