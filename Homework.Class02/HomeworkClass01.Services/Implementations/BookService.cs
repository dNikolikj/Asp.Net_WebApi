using HomeworkClass01.DTOs.BookDtos;
using HomeworkClass01.Services.Interfaces;
using HomeworkClass01.Domain.Models;
using HomeworkClass01.DataAccess;
using HomeworkClass01.Mapers;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace HomeworkClass01.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IGenericRepository<Book> _bookRepository;


        public BookService (IGenericRepository<Book> bookRepository)
        {
          _bookRepository  = bookRepository;
        }
        public void CreateBook(BookDummyDto bookDummyDto)
        {
            if(string.IsNullOrEmpty(bookDummyDto.Title) || string.IsNullOrEmpty(bookDummyDto.AuthorsFullName))
            {
                throw new Exception("The author's name and the book's title are required fields!");
            }
            Book newBook = bookDummyDto.ToDomainBookMapper();
            newBook.Id = ++StaticDb.BookId;
            StaticDb.Books.Add(newBook);
        }

        public List<Book> Filter(string author, string title)
        {
            List<Book> allBooks = _bookRepository.GetAll();

            if (string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
            {
                throw new Exception("The author and title field are required!");
            }

            if (string.IsNullOrEmpty(author) && allBooks.Any(x => x.Title.ToLower() == title.ToLower()))
            {
                List<Book> filteredBooks = allBooks.Where(x => x.Title.ToLower() == title.ToLower()).ToList();
                return filteredBooks;
            }

            
            if (string.IsNullOrEmpty(title) && allBooks.Any(x => x.Author.ToLower() == author.ToLower()))
            {
                List<Book> filteredBooks = allBooks.Where(x => x.Author.ToLower() == author.ToLower()).ToList();
                return filteredBooks;
            }

           
            if (!allBooks.Where(x => x.Author.ToLower() == author.ToLower()).Any(x => x.Title.ToLower() == title.ToLower()))
            {
                throw new Exception("There is no such a book in our library!");
            }

            List<Book> bothParamsPresentbooks = allBooks.Where(x => x.Author.ToLower() == author.ToLower() && x.Title.ToLower() == title.ToLower()).ToList();
            return bothParamsPresentbooks;

        }

        public List<BookDummyDto> GetAllBooks()
        {
            List<Book> booksDb = _bookRepository.GetAll();
            List<BookDummyDto> booksDto = booksDb.Select(b => b.ToBookDummyDto()).ToList();
            return booksDto;
        }

        public BooksTitleDto GetAllTitles()
        {
            List<Book> booksDb = _bookRepository.GetAll();
            if(booksDb == null || booksDb.Count == 0)
            {
                throw new Exception("The are no books in the list at this moment!");
            }
            BooksTitleDto booksTitleDto = booksDb.GetBookTitles();
            return booksTitleDto;
            
        }

        public BookDummyDto GetBookById(int id)
        {
            if(id < 0)
            {
                throw new Exception("The value for the id can not be negative!");
            }
            Book bookDb = _bookRepository.GetById(id);
            if(bookDb == null)
            {
                throw new Exception($"Book with id {id} was not found!");
            }
            BookDummyDto bookDummyDto = bookDb.ToBookDummyDto();
            return bookDummyDto;
        }
    }
}
