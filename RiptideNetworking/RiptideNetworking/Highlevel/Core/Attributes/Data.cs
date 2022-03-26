using System;
using System.Collections.Generic;
using System.Text;

namespace RiptideNetworking.Highlevel.Core
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class Data : Attribute
    {
        public int Id;

        public Data(int id)
        {
            this.Id = id;
        }
    }
}
