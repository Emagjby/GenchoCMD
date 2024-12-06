using GenchoCMD;
using GenchoModels;

namespace Program
{
    public class CMDController
    {
        List<Rectangle> rectangles = new List<Rectangle>();
        RectangleView rectangleView = new RectangleView();

        public CMDController()
        {
            waitForCommand();
        }

        public void waitForCommand()
        {
            bool isRunning = true;
            do
            {
                string[] command = rectangleView.WaitForCommand().Split(' ');
                switch (command.Length > 0 ? command[0].ToLower() : string.Empty)
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
                    case "quit":
                    case "exit":
                    case "x":
                        isRunning = false;
                        break;
                    default:
                        ErrorView.UnknownCommandError(command[0]);
                        break;
                }
            } while (isRunning);
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
                ErrorView.NoSelectedError("Delete");
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
                ErrorView.NoSelectedError("Update");
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
                ErrorView.NoSelectedError("Read");
            }

            SelectedID = null;
        }

        public void Select()
        {
            SelectedID = rectangleView.ReadID();
            if(SelectedID < 0 || SelectedID > rectangles.Count - 1)
            {
                ErrorView.IDNotExistingError(SelectedID ?? 0);
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
