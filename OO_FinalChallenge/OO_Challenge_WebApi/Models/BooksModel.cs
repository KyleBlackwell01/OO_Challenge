using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OO_Challenge_WebApi.Models
{
    public class BooksModel
    {
        public int ISBN { get; set; }
        public string title { get; set; }

        public BooksModel(int ISBN, string title)
        {
            this.ISBN = ISBN;
            this.title = title;
        }
    }
}