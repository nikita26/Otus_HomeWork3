using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Репозиторий для пользователей
    /// </summary>
    public interface IUserRepository:IRepository<User,int>
    {
        User? FindUser(int id, string login);

    }
}
