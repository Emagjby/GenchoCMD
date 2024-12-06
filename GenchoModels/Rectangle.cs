namespace GenchoModels
{
    public class Rectangle
    {
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double Width { get; set; }
        public double Height { get; set; }

        public double Area
        {
            get
            {
                return Width * Height;
            }
        }
    }
}
