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
    public class BorrowedController : ApiController
    {
        // GET: api/Borrowed
        public IEnumerable<BooksBorrowedModel> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<BooksBorrowedModel> output = new List<BooksBorrowedModel>();

            try
            {
                conn.Open();


                query = "select isbn, title, borrower from Books where borrower is not null";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new BooksBorrowedModel(Int32.Parse(rdr["isbn"].ToString()),
                        rdr["title"].ToString(),
                        Int32.Parse(rdr["borrower"].ToString())));
                }

            }
            catch (Exception e)
            {
                output.Clear();
                throw e;
                //output.Add(e.Message);

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
        public IEnumerable<BooksBorrowedModel> Get(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<BooksBorrowedModel> output = new List<BooksBorrowedModel>();

            int output1 = 0;
            string output2 = "";
            int output3 = 0;

            try
            {
                conn.Open();


                query = "select * from Books where borrower =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output1 = Int32.Parse(rdr["isbn"].ToString());
                    output2 = rdr["title"].ToString();
                    output3 = Int32.Parse(rdr["borrower"].ToString());

                    output.Add(new BooksBorrowedModel(output1, output2, output3));


                }

            }
            catch (Exception e)
            {
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
