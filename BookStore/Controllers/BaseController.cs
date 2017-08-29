using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers {

    public abstract class BaseController : Controller {

        protected virtual List<Book> RetrieveBooks() {
            localhost.DataStorage storage = new localhost.DataStorage();
            List<Book> books = new List<Book>();
            string[] bookList = storage.Read();

            for (int i = 0; i < bookList.Length; i++) {
                string[] elements = bookList[i].Split(',');
                Book book = new Book {
                    Index = i + 1,
                    ID = elements[0],
                    Name = elements[1],
                    Author = elements[2],
                    Year = int.Parse(elements[3]),
                    Price = decimal.Parse(elements[4].Substring(1)),
                    Stock = int.Parse(elements[5])
                };
                books.Add(book);
            }
            return books;
        }

        protected virtual void SaveBooks(List<Book> books) {
            localhost.DataStorage storage = new localhost.DataStorage();
            string bookList = string.Empty;
            foreach (Book book in books) {
                bookList += BookToString(book) + '\n';
            }
            storage.Write(bookList.Substring(0, bookList.Length - 1));
        }

        private string BookToString(Book book) {
            return book.ID + ',' + book.Name + ',' + book.Author + ',' +
                   book.Year + ",$" + book.Price + ',' + book.Stock;
        }
    }
}