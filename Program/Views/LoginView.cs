using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Views
{
    public class LoginView
    {
        public string WaitForCommand()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        public void NotLoggedIn()
        {
            Console.WriteLine("You are currently not logged into an account.");
            Console.WriteLine("You can login with > LOGIN\nOr register with > REGISTER\n");
        }

        public void SuccessfulLogin()
        {
            Console.WriteLine("Login Successful!");
        }

        public void FailedLogin()
        {
            Console.WriteLine("Invalid username or password.");
        }

        public void SuccessfulLogout()
        {
            Console.WriteLine("Logged out.");
        }

        public (string Username, string Password) GetLoginDetailsFromUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            return (username, password);
        }

        public (string Username, string Password) GetRegisterDetailsFromUser()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            return (username, password);
        }
    }
}
