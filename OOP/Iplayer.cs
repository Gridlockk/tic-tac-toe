using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal interface IPlayer
    {
         int Move(char[] field, bool side);
    }
}
