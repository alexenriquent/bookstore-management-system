﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers {

    public abstract class BaseController : Controller {

        protected virtual List<Book> InitialiseBooks() {
            localhost.DataStorage storage = new localhost.DataStorage();
            List<Book> books = new List<Book>();
            string[] bookList = storage.Read();

            for (int i = 0; i < bookList.Length; i++) {
                string[] elements = bookList[i].Split(',');
                Book book = new Book {
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

    }
}