using System;
using System.Collections.Generic;
using System.Text;

namespace RiptideNetworking.Highlevel.Core
{
    public static class Writer<T>
    {
        public static Action<Message, T> write;
    }
}
