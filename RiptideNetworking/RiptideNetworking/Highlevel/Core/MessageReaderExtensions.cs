using System;
using System.Collections.Generic;
using System.Text;

namespace RiptideNetworking.Highlevel.Core
{
    public static class MessageReaderExtensions
    {
        public static byte ReadByte(this Message message)
        {
            return message.GetByte();
        }
    }
}
