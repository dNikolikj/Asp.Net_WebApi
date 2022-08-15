using HomeworkClass01.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkClass01.DataAccess.Implementations
{
    public class BookRepository:IGenericRepository<Book>
    {
        public void DeleteById(int id)
        {
            Book bookDb = StaticDb.Books.FirstOrDefault(u => u.Id == id);
            if (bookDb == null)
            {
                throw new Exception($"The book  with id {id} was not found! ");
            }
            StaticDb.Books.Remove(bookDb);
        }

        public List<Book> GetAll()
        {
            return StaticDb.Books;
        }

        public Book GetById(int id)
        {
            return StaticDb.Books.FirstOrDefault(u => u.Id == id);
        }

        public int Insert(Book entity)
        {
            entity.Id = ++StaticDb.UserId;
            StaticDb.Books.Add(entity);
            return entity.Id;
        }

        public void Update(Book entity)
        {
           Book bookDb = StaticDb.Books.FirstOrDefault(e => e.Id == entity.Id);
            if (bookDb == null)
            {
                throw new Exception($"The book  with id {entity.Id} was not found");
            }

            int index = StaticDb.Books.IndexOf(bookDb);
            if (index == -1)
            {
                throw new Exception($"The book with id {entity.Id} was not found");
            }
            StaticDb.Books[index] = entity;
        }
    }
}
