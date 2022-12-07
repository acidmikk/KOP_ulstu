using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Database.Models;
using LibraryContracts.BindingModels;
using LibraryContracts.StorageContracts;
using LibraryContracts.ViewModels;

namespace Database.Implements
{
    public class AuthorStorage : IAuthorStorage
    {
        public List<AuthorViewModel> GetFullList()
        {
            using (var context = new LibraryDatabase())
            {
                return context.Authors
                .Select(CreateModel)
                .ToList();
            };

        }
        public AuthorViewModel GetElement(AuthorBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new LibraryDatabase();

            var shape = context.Authors
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.AuthorName == model.AuthorName);
            return shape != null ? CreateModel(shape) : null;
        }
        public void Insert(AuthorBindingModel model)
        {
            var context = new LibraryDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Authors.Add(CreateModel(model, new Author()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(AuthorBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                var element = context.Authors.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                element.AuthorName = model.AuthorName;
                context.SaveChanges();
            };

        }
        public void Delete(AuthorBindingModel model)
        {
            using (var context = new LibraryDatabase())
            {
                Author element = context.Authors.FirstOrDefault(rec => rec.Id ==
                          model.Id);
                if (element != null)
                {
                    context.Authors.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            };

        }
        private static Author CreateModel(AuthorBindingModel model, Author author)
        {
            author.AuthorName = model.AuthorName;
            return author;
        }
        private static AuthorViewModel CreateModel(Author author)
        {
            return new AuthorViewModel
            {
                Id = author.Id,
                AuthorName = author.AuthorName,
            };
        }
    }
}
