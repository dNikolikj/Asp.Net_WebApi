using HomeworkClass01.DataAccess;
using HomeworkClass01.Services.Interfaces;
using HomeworkClass01.ViewModels.UserViewModels;
using HomeworkClass01.Domain.Models;
using HomeworkClass01.Mapers;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using HomeworkClass01.DTOs.UserViewDTOs;

namespace HomeworkClass01.Services.Implementations
{
    public  class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;


        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public void CreateUser( AddUserDto addUserDto)
        {
            if(string.IsNullOrEmpty(addUserDto.FullName) || string.IsNullOrEmpty(addUserDto.Address))
            {
                throw new Exception("The full name and address fields are required!");
            }

            User newUser = addUserDto.ToDomainUser();

            newUser.Id = ++StaticDb.UserId;
            StaticDb.Users.Add(newUser);

           
            
        }

        public List<UserDetailsDTO> GetAllUsers()
        {
            List<User> usersDb = _userRepository.GetAll();
            List<UserDetailsDTO> usersDetailsDto = usersDb.Select(u => u.ToUserDetailsDto()).ToList();

            return (usersDetailsDto);

        }

        public UserDetailsDTO GetUserById(int id)
        {
            if(id < 0)
            {
                throw new Exception("The id can not be negative!");
            }

           User userDb = _userRepository.GetById(id);
            if(userDb == null)
            {
                throw new Exception($"User with id {id} does not exist!");
            }
            UserDetailsDTO userDetailsDto = userDb.ToUserDetailsDto();
            return userDetailsDto;
        }
    }
}
