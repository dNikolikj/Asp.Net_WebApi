using HomeworkClass01.Domain.Enums;


namespace HomeworkClass01.ViewModels.UserViewModels
{
    public  class UserDetailsDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public UserTypeEnum TypeOfUser { get; set; }
    }
}
