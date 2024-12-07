using GenchoCMD.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenchoCMD
{
    internal class Administrator : IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get => true; }
    }
}
