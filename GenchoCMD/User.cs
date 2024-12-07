using GenchoCMD.IModels;

namespace GenchoCMD
{
    public class User : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get => false; }
    }
}
