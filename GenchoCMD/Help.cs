using GenchoCMD.IModels;

namespace GenchoCMD
{
    public class Help : ICommand
    {
        public string Name { get => "Help";  }

        public void Execute(string command)
        {
            command = command.ToLower();

            switch (command)
            {
                case "help":
                    Output(
                        "> HELP [COMMAND]\n" +
                        "   COMMAND - displays information about that command"
                        );
                    break;
                case "list":
                    Output(
                        "> LIST\n" +
                        "   Outputs all of your created objects"
                        );
                    break;
                case "create":
                    Output(
                        "> CREATE\n" +
                        "   Starts a Create GUI, used to create new objects"
                        );
                    break;
                case "select":
                    Output(
                        "> SELECT \n" +
                        "   Starts a Select GUI, to select ID"
                        );
                    break;
                case "delete":
                    Output(
                        "> DELETE\n" +
                        "   Deletes the currently selected object."
                        );
                    break;
                case "edit":
                    Output(
                        "> EDIT\n" +
                        "   Starts an Edit GUI, used to update the selected object"
                        );
                    break;
                case "read":
                    Output(
                        "> READ\n" +
                        "   Outputs the selected object."
                        );
                    break;
                case "clear":
                    Output(
                        "> CLEAR\n" +
                        "   Clears the screen."
                        );
                    break;
                case "logout":
                    Output(
                        "> LOGOUT\n" +
                        "   Logs the user out of the account.");
                    break;
                default:
                    Output(
                        $"Available commands: create, read, list, edit, delete, select, help, clear, logout\n" +
                        "For specific info about a command - HELP [COMMAND]\n" +
                        "   COMMAND - displays information about that command"
                        );
                    break;
            }
        }

        public void Input(string[] input)
        {
            Execute(input?.FirstOrDefault() ?? string.Empty);
        }

        public void Output(string output)
        {
            Console.WriteLine(output + "\n");
        }

        public Help(string[] input)
        {
            Input(input);
        }
    }
}
