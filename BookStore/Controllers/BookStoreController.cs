using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers {

    public class BookStoreController : BaseController {

        public ActionResult Index() {
            return View();
        }

        public ActionResult GetAllBooks() {
            ViewBag.books = BookManager.GetAllBooks();
            return View();
        }

        [HttpGet]
        public ActionResult AddBook() {
            ViewBag.books = BookManager.GetAllBooks();
            return View(new Book());
        }

        [HttpPost]
        public ActionResult AddBook(Book book) {
            BookManager.AddBook(book);
            return Redirect("/BookStore/AddBook");
        }

        [HttpGet]
        public ActionResult DeleteBook() {
            ViewBag.books = BookManager.GetAllBooks();
            return View(new Book());
        }

        [HttpPost]
        public ActionResult DeleteBook(string attribute, Book book) {
            BookManager.DeleteBook(attribute, book);
            return Redirect("/BookStore/DeleteBook");
        }
    }
}