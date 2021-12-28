using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr7
{
    class Exceptions : Exception
    {
        public Exceptions(string msg) : base(msg)
        {
        }
    }
    class CandyExeption : Exceptions
    {
        public CandyExeption(string msg) : base(msg)
        {
        }
    }
    class CookieExeption : Exceptions
    {
        public CookieExeption(string msg) : base(msg)
        {
        }
    }
    class ChocolateBarExeption : Exceptions
    {
        public ChocolateBarExeption(string msg) : base(msg)
        {
        }
    }
}
