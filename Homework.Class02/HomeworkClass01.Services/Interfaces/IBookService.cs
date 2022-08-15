using HomeworkClass01.DataAccess;
using HomeworkClass01.DTOs.BookDtos;
using HomeworkClass01.Domain.Models;
namespace HomeworkClass01.Services.Interfaces
{
  public  interface IBookService
    {
        List<BookDummyDto> GetAllBooks();

       BookDummyDto GetBookById(int id);

        void CreateBook(BookDummyDto bookDummyDto);
        List<Book> Filter(string author, string title);

        BooksTitleDto GetAllTitles();

        
    }
}
