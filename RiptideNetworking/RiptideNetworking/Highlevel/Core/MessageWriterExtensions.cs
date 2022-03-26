using System;
using System.Collections.Generic;
using System.Text;

namespace RiptideNetworking.Highlevel.Core
{
    public static class MessageWriterExtensions
    {
        public static void WriteByte(this Message message, byte value)
        {
            message.AddByte(value);
        }
    }
}
