using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind
{
   public interface iDialer
    {
        bool Dial(string number);
    }
}
