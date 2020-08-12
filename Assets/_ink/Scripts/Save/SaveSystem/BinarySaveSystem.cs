using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace ink.Save
{
    public class BinarySaveSystem : SaveSystem
    {
        public override void SaveFile(object state)
        {
            using (var stream = File.Open(SavePath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
        }

        public override object LoadFile()
        {
            if (!File.Exists(SavePath))
            {
                return null;
            }

            using (var stream = File.Open(SavePath, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                return formatter.Deserialize(stream);
            }
        }
    }
}
