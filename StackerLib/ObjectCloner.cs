using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace StackerLib
{
    public static class ObjectCloner
    {
        public static T DeepClone<T>(T source) where T : class
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, source);
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }
    }
}
