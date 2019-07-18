using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates.Extenstions
{

    // in C#, static utility methods can becomeextenstion methods
    //which get attached to the class you're operating on.
    public static class Extenstions
    {

        // called like:"abc".VowleCount(true)
        public static int VowelCount(this string s, bool option)
        {
            return 0;
        }
    }
}
