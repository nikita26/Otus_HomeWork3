using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Services.Repositories.Abstractions;
using Infrastructure.EntityFramework;

namespace Infrastructure.Repositories.Implementations
{
    public class UserRepository:Repository<User,int>,IUserRepository
    {
        public UserRepository(DataBaseContext context) : base(context)
        {
        }

        /// <summary>
        /// Поиск пользователя по идентификатору и логину
        /// </summary>
        /// <param name="id"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public User? FindUser(int id, string login)
        {
            return EntitySet.FirstOrDefault(s => s.Id == id || s.Login == login);
        }

    }
}
