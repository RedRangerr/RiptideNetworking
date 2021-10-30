﻿using System.Reflection;

namespace RiptideNetworking
{
    /// <summary>The state of a connection.</summary>
    enum ConnectionState : byte
    {
        /// <summary>Not connected. No connection has been established or the connection has been disconnected again.</summary>
        notConnected,
        /// <summary>Connecting. Still trying to establish a connection.</summary>
        connecting,
        /// <summary>Connected. A connection was successfully established.</summary>
        connected,
    }

    /// <summary>Contains shared functionality for <see cref="Server"/> and <see cref="Client"/>.</summary>
    public abstract class Common
    {
        /// <summary>Whether or not to output informational log messages. Error-related log messages ignore this setting.</summary>
        public abstract bool ShouldOutputInfoLogs { get; set; }

        /// <summary>Searches the given assembly for methods with the <see cref="MessageHandlerAttribute"/> and adds them to the dictionary of handler methods.</summary>
        /// <param name="assembly">The assembly to search for methods with the <see cref="MessageHandlerAttribute"/>.</param>
        /// <param name="messageHandlerGroupId">The ID of the group of message handler methods to use when building the message handlers dictionary.</param>
        protected abstract void CreateMessageHandlersDictionary(Assembly assembly, byte messageHandlerGroupId);

        /// <summary>Initiates handling of currently queued messages.</summary>
        /// <remarks>This should generally be called from within a regularly executed update loop (like FixedUpdate in Unity). Messages will continue to be received in between calls, but won't be handled fully until this method is executed.</remarks>
        public abstract void Tick();
    }
}