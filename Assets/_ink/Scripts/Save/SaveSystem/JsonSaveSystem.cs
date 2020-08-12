using System.IO;
using UnityEngine;

namespace ink.Save
{
    public class JsonSaveSystem : SaveSystem
    {
        public override void SaveFile(object state)
        {
            using (var stream = File.Open(SavePath, FileMode.Create))
            {
                //var formatter = new BinaryFormatter();
                //formatter.Serialize(stream, state);
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
                //var formatter = new BinaryFormatter();
                //return formatter.Deserialize(stream);
                return null;
            }
        }
    }
}
