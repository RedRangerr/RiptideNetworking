using System;
using System.Collections.Generic;
using System.Text;

namespace RiptideNetworking.Highlevel.Core
{
    public interface IMessage
    {
        MessageSendMode SendMode { get; }

        ushort MessageId { get; }

        int MaxSendAttempts { get; }

        bool AutoRelay { get; }
    }
}
