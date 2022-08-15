using HomeworkClass01.Domain.Models;
using System.Reflection.Metadata.Ecma335;

namespace HomeworkClass01.DataAccess.Implementations
{
    public class UserRepository : IGenericRepository<User>
    {
        public void DeleteById(int id)
        {
            User userDb = StaticDb.Users.FirstOrDefault(u => u.Id == id);
            if(userDb == null)
            {
                throw new Exception($"The user with id {id} was not found! ");
            }
            StaticDb.Users.Remove(userDb);
        }

        public List<User> GetAll()
        {
            return StaticDb.Users;
        }

        public User GetById(int id)
        {
            return StaticDb.Users.FirstOrDefault(u => u.Id == id);
        }

        public int Insert(User entity)
        {
            entity.Id = ++StaticDb.UserId;
            StaticDb.Users.Add(entity);
            return entity.Id;
        }

        public void Update(User entity)
        {
            User userDb = StaticDb.Users.FirstOrDefault(e => e.Id == entity.Id);
            if(userDb == null)
            {
                throw new Exception($"The user with id {entity.Id} was not found");
            }

            int index = StaticDb.Users.IndexOf(userDb);
            if(index == -1)
            {
                throw new Exception($"The user with id {entity.Id} was not found");
            }
            StaticDb.Users[index] = entity;
        }
    }
}
