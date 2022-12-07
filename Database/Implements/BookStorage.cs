using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using LibraryContracts.BindingModels;
using LibraryContracts.ViewModels;
using LibraryContracts.StorageContracts;

namespace Database.Implements
{
    public class BookStorage : IBookStorage
    {
        public void Delete(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                Book element = context.Books.FirstOrDefault(rec => rec.Id ==
                          model.Id);
                if (element != null)
                {
                    context.Books.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            };

        }

        public BookViewModel GetElement(BookBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new LibraryDatabase())
            {
                var component = context.Books
            .FirstOrDefault(rec => rec.BookName == model.BookName || rec.Id
           == model.Id);
                return component != null ? CreateModel(component) : null;
            };


        }

        public List<BookViewModel> GetFilteredList(BookBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new LibraryDatabase())
            {
                return context.Books
            .Where(rec => rec.BookName.Contains(model.BookName))
            .Select(CreateModel)
            .ToList();
            };


        }

        public List<BookViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Books
            .Select(CreateModel)
            .ToList();
            };

        }

        public void Insert(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                context.Books.Add(CreateModel(model, new Book(), context));
                context.SaveChanges();
            };

        }

        public void Update(BookBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var element = context.Books.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            };

        }
        private static Book CreateModel(BookBindingModel model, Book book, LibraryDatabase context)
        {
            book.BookName = model.BookName;
            book.DateOut = model.DateOut;
            book.Author = model.Author;
            book.Image = model.Image;

            return book;
        }
        private static BookViewModel CreateModel(Book book)
        {
            return new BookViewModel
            {
                Id = book.Id,
                BookName = book.BookName,
                DateOut = book.DateOut,
                Image = book.Image,
                Author = book.Author,
            };
        }
    }
}
