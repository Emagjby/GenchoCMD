using GenchoModels;

namespace Program
{
    public class RectangleView
    {
        public string WaitForCommand()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }

        public int ReadID()
        {
            Console.Write("Enter ID: ");
            return int.Parse(Console.ReadLine());
        }

        public void DisplayRectangle(Rectangle rectangle, int id)
        {
            Console.WriteLine(
                "Rectangle[{3}] - Width: {0}, Height: {1}, Area: {2}", 
                rectangle.Width, rectangle.Height, rectangle.Area, id
                );
        }

        public (double Width, double Height) GetRectangleDimensionsFromUser()
        {
            Console.Write("Enter the width of the rectangle: ");
            double width = double.Parse(Console.ReadLine());

            Console.Write("Enter the height of the rectangle: ");
            double height = double.Parse(Console.ReadLine());

            return (width, height);
        }
    }
}
