using RiptideNetworking.Highlevel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RiptideNetworking.Highlevel.CodeGeneration
{
    public static class MessageHelpers
    {
        public static Message CreateMessage(IMessage message)
        {
            Message newMessage = Message.Create(message.SendMode, message.MessageId, message.MaxSendAttempts, message.AutoRelay);
            var fields = message.GetType().GetFields().ToList().Where(field => Attribute.IsDefined(field, typeof(Data)));
            fields.OrderBy(field => GetFieldId(field));

            foreach(var field in fields)
            {
                HandleMessageData(newMessage, message, field);
            }
           
            return newMessage;
        }

        private static int GetFieldId(FieldInfo field)
        {
            Data data = (Data)field.GetCustomAttribute(typeof(Data), true);
            return data.Id;
        }

        private static void HandleMessageData(Message curMessage, IMessage originMessage, FieldInfo field)
        {
            if (field.GetType() == typeof(byte))
            {
                Writer<byte>.write.Invoke(curMessage, (byte)field.GetValue(originMessage));
            }
            else
                throw new Exception($"Cannot write field with type {field.GetType()}!");
        }


        private static void InitWriters()
        {
            Writer<byte>.write = new Action<Message, byte>(MessageWriterExtensions.WriteByte);
        }

        private static void InitReaders()
        {
            Reader<byte>.read = new Func<Message, byte>(MessageReaderExtensions.ReadByte);
        }
    }
}
