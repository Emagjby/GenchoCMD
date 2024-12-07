using ConsoleApp.Views;
using GenchoCMD;
using GenchoModels;
using System.Configuration;
using System.Data.OleDb;

namespace Program
{
    public class CMDController
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        RectangleView rectangleView = new RectangleView();
        ErrorView errorView = new ErrorView();
        LoginView loginView = new LoginView();

        public string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=../../../Database.accdb;";
        public int? LogedInUserID = null;
        public string? LogedInUsername = null;

        public CMDController()
        {
            waitForCommand();
        }

        public void RemoveFromDb()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            string querry = "DELETE " +
                "FROM Rectangles " +
                "WHERE UserID = ?";

            OleDbCommand command = new OleDbCommand(querry, connection);
            command.Parameters.AddWithValue("?", LogedInUserID);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public void SaveToDb()
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            for(int i = 0; i < rectangles.Count; i++)
            {
                var rect = rectangles[i];

                string queue = "INSERT INTO Rectangles ([RectangleID],[UserID],[Width],[Height])" +
                $"VALUES ('{i}', '{LogedInUserID}', '{rect.Width}', '{rect.Height}')";

                OleDbCommand command = new OleDbCommand (queue, connection);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public void Register()
        {
            EmptyRectanglesList();

            var (username, password) = loginView.GetRegisterDetailsFromUser();

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            string querry = "INSERT INTO Users ([Username], [Password]) " +
                $"VALUES ('{username}', '{password}')";
            try{
                OleDbCommand command = new OleDbCommand(querry, connection);
                command.ExecuteNonQuery();

                querry = "SELECT [UserID], [Username]" +
                    "FROM Users " +
                    $"WHERE Username = ? AND Password = ?";

                command = new OleDbCommand(querry, connection);
                command.Parameters.AddWithValue("?", username);
                command.Parameters.AddWithValue("?", password);

                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    LogedInUserID = Convert.ToInt32(reader["UserID"]);
                    LogedInUsername = Convert.ToString(reader["Username"]);
                    loginView.SuccessfulLogin();
                }
                else
                {
                    loginView.FailedLogin();
                }
                    reader.Close(); 
            } catch(Exception ex)
            {
                Console.WriteLine("This username already exists, or you used illegal characters");
            }
            connection.Close();
        }

        public void EmptyRectanglesList()
        {
            rectangles = new List<Rectangle>();
        }

        public void LoadRectanglesFromDb()
        {
            EmptyRectanglesList();

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            string query = "SELECT [Width], [Height] " +
                           "FROM Rectangles " +
                           "WHERE UserID = ? " +
                           "ORDER BY RectangleID ASC";

            OleDbCommand command = new OleDbCommand(query, connection);
            command.Parameters.AddWithValue("?", LogedInUserID);

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                double width = reader.GetDouble(0); 
                double height = reader.GetDouble(1); 
                rectangles.Add(new Rectangle(width, height)); // Add to list
            }

            connection.Close();

            Console.WriteLine("Loaded " + rectangles.Count + " rectangles for UserID: " + LogedInUserID);
        }


        public void Login()
        {
            var (username, password) = loginView.GetLoginDetailsFromUser();

            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            string querry = "SELECT [UserID], [Username]" +
                "FROM Users " +
                $"WHERE Username = ? AND Password = ?";

            OleDbCommand command = new OleDbCommand(querry, connection);
            command.Parameters.AddWithValue("?", username);
            command.Parameters.AddWithValue("?", password);

            OleDbDataReader reader = command.ExecuteReader();
            if(reader.Read())
            {
                LogedInUserID = Convert.ToInt32(reader["UserID"]); ;
                LogedInUsername = Convert.ToString(reader["Username"]);
                loginView.SuccessfulLogin();
                EmptyRectanglesList();
                LoadRectanglesFromDb();
            }
            else
            {
                loginView.FailedLogin();
            }
            reader.Close();

            connection.Close();
        }

        public void Logout()
        {
            RemoveFromDb();
            SaveToDb();
            LogedInUserID = null;
            LogedInUsername = null;
            loginView.SuccessfulLogout();
        }

        public void waitForCommand()
        {
            bool isRunning = true;
            while (isRunning)
            {
                loginView.NotLoggedIn();
                do
                {
                    string[] command = loginView.WaitForCommand().Split(" ").Select((item) => item.ToLower()).ToArray();
                    switch(command.Length > 0 ? command[0] : string.Empty)
                    {
                        case "login":
                            Login();
                            break;
                        case "register":
                            Register();
                            break;
                        case "quit":
                        case "exit":
                        case "x":
                            isRunning = false;
                            break;
                        default:
                            errorView.UnknownCommandError(command[0]);
                            break;
                    }

                } while (LogedInUserID == null && isRunning);

                if (!isRunning) break;

                do
                {
                    string[] command = rectangleView.WaitForCommand(LogedInUsername).Split(' ').Select((item) => item.ToLower()).ToArray();
                    switch (command.Length > 0 ? command[0] : string.Empty)
                    {
                        case "help":
                            Help help = new Help(command.Length > 1 ? new string[] { command[1] } : []);
                            break;
                        case "create":
                            Create();
                            break;
                        case "read":
                            Read();
                            break;
                        case "list":
                            List();
                            break;
                        case "edit":
                            Update();
                            break;
                        case "select":
                            Select();
                            break;
                        case "delete":
                            Delete();
                            break;
                        case "clear":
                            Console.Clear();
                            break;
                        case "logout":
                        case "quit":
                        case "exit":
                        case "x":
                            Logout();
                            break;
                        default:
                            errorView.UnknownCommandError(command[0]);
                            break;
                    }
                } while (LogedInUserID != null && isRunning);
            }
        }

        public int? SelectedID = null;

        public void Create()
        {
            var (width, height) = rectangleView.GetRectangleDimensionsFromUser();
            Rectangle rect = new Rectangle(width, height);
            rectangles.Add(rect);
        }

        public void Delete()
        {
            if (SelectedID != null)
            {
                rectangles.RemoveAt(SelectedID ?? 0);
            }
            else
            {
                errorView.NoSelectedError("Delete");
            }

            SelectedID = null;
        }

        public void Update()
        {
            if(SelectedID != null)
            {
                var (width, height) = rectangleView.GetRectangleDimensionsFromUser();
                rectangles[SelectedID ?? 0].Width = width;
                rectangles[SelectedID ?? 0].Height = height;
            }
            else
            {
                errorView.NoSelectedError("Update");
            }

            SelectedID = null;
        }

        public void Read()
        {
            if(SelectedID != null)
            {
                rectangleView.DisplayRectangle(rectangles[SelectedID ?? 0], SelectedID ?? 0);
            }
            else
            {
                errorView.NoSelectedError("Read");
            }

            SelectedID = null;
        }

        public void Select()
        {
            SelectedID = rectangleView.ReadID();
            if(SelectedID < 0 || SelectedID > rectangles.Count - 1)
            {
                errorView.IDNotExistingError(SelectedID ?? 0);
                SelectedID = null;
            }
        }

        public void List()
        {
            foreach(var rect in rectangles)
            {
                rectangleView.DisplayRectangle(rect, rectangles.IndexOf(rect));
            }
        }
    }
}
