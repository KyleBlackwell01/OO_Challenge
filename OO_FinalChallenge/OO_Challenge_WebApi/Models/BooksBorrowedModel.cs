using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OO_Challenge_WebApi.Models
{
    public class BooksBorrowedModel
    {
        public int ISBN { get; set; }
        public string title { get; set; }
        //public int publishedYear { get; set; }
        public int borrower { get; set; }
        //public int author { get; set; }

        public BooksBorrowedModel(int ISBN, string title, int borrower)
        {
            this.ISBN = ISBN;
            this.title = title;
            this.borrower = borrower;
        }
    }
}