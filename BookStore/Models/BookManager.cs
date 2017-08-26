using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models {
    public static class BookManager {
        private static List<Book> books = new List<Book>();
        private static localhost.DataStorage storage = new localhost.DataStorage();

        private static void InitialiseBooks() {
            books.Clear();
            string[] bookList = storage.Read();
            for (int i = 0; i < bookList.Length; i++) {
                Book book = new Book();
                string[] elements = bookList[i].Split(',');
                book.ID = elements[0];
                book.Name = elements[1];
                book.Author = elements[2];
                book.Year = int.Parse(elements[3]);
                book.Price = decimal.Parse(elements[4].Substring(1));
                book.Stock = int.Parse(elements[5]);
                books.Add(book);
            }
        }

        public static List<Book> GetAllBooks() {
            InitialiseBooks();
            return books;
        }

        public static void AddBook(Book book) {
            books.Add(book);
            storage.Write(BookString());
        }

        public static void DeleteBook(string attribute, Book book) {
            switch (attribute) {
                case "num": books.RemoveAll(x => x.Index == book.Index); break;
                case "id": books.RemoveAll(x => x.ID == book.ID); break;
                case "name": books.RemoveAll(x => x.Name == book.Name); break;
                case "author": books.RemoveAll(x => x.Author == book.Author); break;
                case "year": books.RemoveAll(x => x.Year == book.Year); break;
            }
            storage.Write(BookString());
        }

        private static string BookString() {
            string bookList = string.Empty;
            foreach (Book book in books) {
                bookList += BookToString(book) + '\n';
            }
            return bookList.Substring(0, bookList.Length - 1);
        }

        private static string BookToString(Book book) {
            return book.ID + ',' + book.Name + ',' + book.Author + ',' + 
                   book.Year + ",$" + book.Price + ',' + book.Stock;
        }

    }
}