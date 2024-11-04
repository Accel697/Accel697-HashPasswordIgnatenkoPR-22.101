using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HashPassword;
using practic5.Models;

namespace practic5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper.GetContext();
            Helper helper = new Helper();
            Hash hash = new Hash();

            Console.WriteLine("Введите логин: ");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль: ");
            string password = Console.ReadLine();
            Console.WriteLine("Введите ID сотрудника: ");
            int idEmployee = int.Parse(Console.ReadLine());

            string hashPassw = hash.hashPassword(password);
            Console.WriteLine($"Хэшированный пароль: {hashPassw}");

            User user = new User();
            user.Login = login;
            user.Password = hashPassw;
            user.Employee = idEmployee;

            helper.CreateUser(user);

            Console.WriteLine("Учетная запись добавлена");

            Console.ReadLine();
        }
    }
}
