using Domain.Entities;
using Services.Contracts;

namespace Services.Abstractons
{
    public interface IUserService
    {
        /// <summary>
        /// Получить все
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserDto> GetAll();

        /// <summary>
        /// Получить по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        UserDto GetById(int id);

        /// <summary>
        /// Создать
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        UserDto Create(UserDto comment);

        /// <summary>
        /// Обновить
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        bool Update(UserDto comment);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);

        /// <summary>
        /// Поиск пользователя по идентификатору и логину
        /// </summary>
        /// <param name="id"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        UserDto? FindUser(int id, string login);
    }
}