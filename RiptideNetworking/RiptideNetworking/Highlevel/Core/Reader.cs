using System;
using System.Collections.Generic;
using System.Text;

namespace RiptideNetworking.Highlevel.Core
{
    public static class Reader<T>
    {
        public static Func<Message, T> read;
    }
}
