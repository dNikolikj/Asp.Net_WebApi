using HomeworkClass01.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkClass01.DTOs.UserViewDTOs
{
    public  class AddUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }

        public UserTypeEnum TypeOfUser { get; set; }
    }
}
