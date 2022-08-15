using HomeworkClass01.Domain.Models;
using HomeworkClass01.DTOs.UserViewDTOs;
using HomeworkClass01.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkClass01.Mapers
{
   public  static class AddUserMapper
    {
        public static AddUserDto ToAddUserDto(this User userDb)
        {
            return new AddUserDto
            {
                Id = userDb.Id,
                FullName = $"{userDb.FirstName} {userDb.FirstName}",
                Address = userDb.Address,
                TypeOfUser = userDb.TypeOfUser,
            };
        }
    }
}
