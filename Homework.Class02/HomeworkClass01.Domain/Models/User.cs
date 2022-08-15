using HomeworkClass01.Domain.Enums;

namespace HomeworkClass01.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public UserTypeEnum TypeOfUser { get; set; }


    }
}
