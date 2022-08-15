using HomeworkClass01.Domain.Models;
using HomeworkClass01.DTOs.UserViewDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkClass01.Mapers
{
   public static  class ToDomainUserMapper
    {
        public static User ToDomainUser(this AddUserDto addUserDto)
        {
             string [] splittedFullName = addUserDto.FullName.Split(' ');
            return new User
            {
                Id = addUserDto.Id,
                FirstName = splittedFullName[0],
                LastName = splittedFullName[1],
                Address = addUserDto.Address,
                TypeOfUser = addUserDto.TypeOfUser

               
            };
        }
    }
}
