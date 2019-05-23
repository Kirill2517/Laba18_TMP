using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp12
{

    public class UserController
    {

        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        private const string USERS_FILE_NAME = "users.json";
        public bool ex { get; } = false;

        public UserController(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentNullException("Login пользователя не может быть пустым", nameof(login));
            Users = GetUsersData();
            if (Users.Single(u => u.Login == login) != null)
            {
                CurrentUser = Users.First(u => u.Login == login);
                if (CurrentUser.Password == password) ex = true;
            }
        }

        public UserController(string login, string name, string password, int age)
        {
            if (string.IsNullOrWhiteSpace(login))
                throw new ArgumentNullException("Login пользователя не может быть пустым", nameof(login));

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(u => u.Login == login);

            if (CurrentUser == null)
            {
                if (age != 0)
                    CurrentUser = new User(name, login, password, age);
                else CurrentUser = new User(name, login, password);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save(USERS_FILE_NAME, Users);
            }
            else IsNewUser = false;
        }

        /// <summary>
        /// Получить сохраненные данные пользователей.
        /// </summary>
        /// <returns>Сохраненные данные пользователей.</returns>
        private List<User> GetUsersData()
        {
            return Load(USERS_FILE_NAME) ?? new List<User>();
        }

        public void SetNewUserData(string password, string name, int age = 0)
        {
            //Проверка
            if(age != 0)
                CurrentUser.Age = age;
            CurrentUser.Password = password;
            CurrentUser.Name = name;

            Save(USERS_FILE_NAME, Users);
        }

        /// <summary>
        /// Записываем в файл.
        /// </summary>
        /// <param name="FileName">Имя файла.</param>
        /// <param name="item">То что нужно записать.</param>
        protected void Save(string FileName, object item)
        {
            var formatter = new DataContractJsonSerializer(typeof(List<User>));

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, item);
            }
        }
        /// <summary>
        /// Получаем содержимое файла.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="FileName">Имя файла из которого надо получить данные.</param>
        /// <returns></returns>
        protected List<User> Load(string FileName)
        {
            var formatter = new DataContractJsonSerializer(typeof(List<User>));

            using (var fs = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.ReadObject(fs) is List<User> items)
                {
                    return items;
                }
                //defult - значение по умолчанию для типа T.
                else return default;
            }
        }
    }
}