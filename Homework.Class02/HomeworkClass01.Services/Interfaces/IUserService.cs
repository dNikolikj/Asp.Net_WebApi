using HomeworkClass01.DTOs.UserViewDTOs;
using HomeworkClass01.ViewModels.UserViewModels;

namespace HomeworkClass01.Services.Interfaces
{
     public  interface IUserService
    {
        List<UserDetailsDTO> GetAllUsers();

        UserDetailsDTO GetUserById(int id);

        void CreateUser(AddUserDto addUserDto);
        
    }
}
