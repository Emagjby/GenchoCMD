using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public static class ErrorView
    {
        public static void NoSelectedError(string action)
        {
            Console.WriteLine("You need to select an object from the list in order to {0} it.", action);
            Console.WriteLine("To select an object run the command > Select [ID]");
        }

        public static void IDNotExistingError(int id)
        {
            Console.WriteLine("An object with the ID of {0} does not exist.", id);
        }

        public static void UnknownCommandError(string command)
        {
            Console.WriteLine("\'{0}\' is not a recognized command. Run > help to output available commands.", command);
        }
    }
}
