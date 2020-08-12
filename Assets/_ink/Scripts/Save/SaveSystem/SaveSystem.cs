using UnityEngine;

namespace ink.Save
{
    public abstract class SaveSystem
    {
        protected string SavePath => $"{Application.persistentDataPath}/save.txt";

        public abstract void SaveFile(object state);

        public abstract object LoadFile();
    }
}
