using UnityEngine;

namespace ink.Save
{
    public interface ISaveable 
    {
        object SaveData();
        void LoadData(object data);
    }
}
