using HomeworkClass01.Domain.Models;
using HomeworkClass01.DTOs.BookDtos;



namespace HomeworkClass01.Mapers
{
   public static  class BookTitlesMapper
    {
        public static BooksTitleDto GetBookTitles(this List<Book> books)
        {
            return new BooksTitleDto()
            {
                BookTitles = books.Select(b => b.Title).ToList()
            };
        }
    }
}
