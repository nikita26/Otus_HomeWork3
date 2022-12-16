using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Services.Contracts;
using System.Net;
using System.Text;
using System.Text.Json;

namespace HomeWork3_Client
{
    public class Program
    {
        static HttpClient http;
        public static void Main(string[] args)
        {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var createUserUri = config.GetSection("createUserUri").Value;
            var findUserUri = config.GetSection("findUserUri").Value;

            if (createUserUri == null || findUserUri == null)
                throw new Exception("Конфигурация приложения не найдена либо не полная");

            http = new HttpClient();
            
            while (true)
            {
                Console.WriteLine("1. Создать пользователя");
                Console.WriteLine("2. Найти пользователя");
                if (Console.ReadLine() == "1")
                    CreateNewUser(createUserUri);
                else
                    FindUserById(findUserUri);
            }

        }

        /// <summary>
        /// Создание сгенерированного пользователя
        /// </summary>
        static async void CreateNewUser(string methodUri)
        {
            try
            {
                var randId = new Random().Next(1, 5);
                var randLogin = new Random().Next(1, 5);
                var newUser = new UserDto()
                {
                    Id = randId,
                    Login = "login" + randLogin,
                    Password = "123pass",
                    Name = "userName",
                    Surname = "S",
                    Patronimic = "p",
                    Email = "user@mail.ru"
                };

                var json = JsonSerializer.Serialize(newUser);

                var requestPost = new HttpRequestMessage(HttpMethod.Post, methodUri);
                requestPost.Content = new StringContent(json, Encoding.UTF8, "application/json");

                var responsePost = http.Send(requestPost);

                Console.WriteLine();
                Console.WriteLine("Создаем пользователя: " + json + "\n");
                Console.WriteLine(responsePost.StatusCode);
                Console.WriteLine(await responsePost.Content.ReadAsStringAsync());
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }


        }

        /// <summary>
        ///  Поиск пользователя по идентификатору
        /// </summary>
        static async void FindUserById(string methodUri)
        {
            try
            {
                Console.Write("Введите Id пользователя:");
                var idS = Console.ReadLine();
                var id = 0;
                while (!int.TryParse(idS, out id))
                {
                    Console.Write("Id пользователя должно быть целым числом:");
                    idS = Console.ReadLine();
                }

                var request = new HttpRequestMessage(HttpMethod.Get, methodUri + "?id=" + id.ToString());

                var response = http.Send(request);

                Console.WriteLine();
                Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
        }
    }
}



