using BookStoreManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStoreManagementSystem.Controllers {

    public abstract class BaseController : Controller {

        protected virtual void SaveBooks(List<S4452232> books) {
            localhost.DataStorage storage = new localhost.DataStorage();
            string bookList = string.Empty;
            foreach (S4452232 book in books) {
                bookList += BookToString(book) + '\n';
            }
            storage.Write(bookList.Substring(0, bookList.Length - 1));
        }

        private string BookToString(S4452232 book) {
            return book.ID + ',' + book.Name + ',' + book.Author + ',' +
                   book.Year + ",$" + book.Price + ',' + book.Stock;
        }

        protected virtual void UpdateDatabase() {
            using (var db = new BookDBContext()) {
                int index = 1;
                foreach (S4452232 book in db.S4452232) {
                    book.Index = index;
                    index++;
                }
                db.SaveChanges();
            }
        }
    }
}