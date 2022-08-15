
using HomeworkClass01.Domain.Enums;
using HomeworkClass01.Domain.Models;
using HomeworkClass01.ViewModels.UserViewModels;
namespace HomeworkClass01.Mapers
{
    public static class UserDetailsMapper
    {
        public static UserDetailsDTO ToUserDetailsDto(this User userDb)
        {
            return new UserDetailsDTO
            {
                Id = userDb.Id,
                FullName = $"{userDb.FirstName} {userDb.FirstName}",
                Address = userDb.Address,
                TypeOfUser = userDb.TypeOfUser,
            };
        }

    }
}
