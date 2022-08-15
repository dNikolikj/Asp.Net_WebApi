using HomeworkClass01.DTOs.BookDtos;
using HomeworkClass01.Domain.Models;

namespace HomeworkClass01.Mapers
{
   public static class DummyBookMapper
    {
        public static BookDummyDto ToBookDummyDto(this Book bookDb)
        {
            return new BookDummyDto()
            {
                Id = bookDb.Id,
                AuthorsFullName = bookDb.Author,
                Title = bookDb.Title
            };
        }

        public static Book ToDomainBookMapper(this BookDummyDto bookDummyDto)
        {
            return new Book()
            {
                Id = bookDummyDto.Id,
                Author = bookDummyDto.AuthorsFullName,
                Title = bookDummyDto.Title
            };
        }
    }
}
