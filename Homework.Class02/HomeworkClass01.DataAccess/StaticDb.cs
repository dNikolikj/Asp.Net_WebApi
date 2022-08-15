using HomeworkClass01.Domain.Models;
using HomeworkClass01.Domain.Enums;


namespace HomeworkClass01.DataAccess
{
    public static class StaticDb
    {
        public static int UserId { get;  set; }
        public static int BookId { get; set; }

        public static List<User> Users { get;  set; }
        public static List<Book> Books { get; set; }

        static StaticDb()
        {
            UserId = 3;
            BookId = 3;

            Users = new List<User>()
            {
                new User ()
                {
                    Id = 1,
                    FirstName = "Darko",
                    LastName = "Nikolikj",
                    Address = "Sesame street",
                    TypeOfUser = UserTypeEnum.Administrator
                },

                new User()
                {
                    Id = 2,
                    FirstName = "Greg",
                    LastName = "Bavarro",
                    Address = "Didn't street",
                    TypeOfUser = UserTypeEnum.RegisteredUser
                },

                new User()
                {
                    Id = 3,
                    FirstName = "Darko",
                    LastName = "Dejanovski",
                    Address = "The moon",
                    TypeOfUser= UserTypeEnum.Guest
                }
            };
            Books = new List<Book>()
            {
                new Book ()
                {
                    Id= 1,
                    Author = "Pol Ekman",
                    Title = "Lazi me"
                },
                new Book ()
                {
                    Id = 2,
                    Author ="Ekart Tol",
                    Title ="Mokjta na segashniot mig",

                },
                new Book ()
                {
                    Id = 3,
                    Author ="Fjodor M. Dostoevski",
                    Title ="Idiot"
                }

            };

            

        }
    }
}
