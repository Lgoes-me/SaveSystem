using UnityEngine;

namespace ink.Save
{
    public interface ISaveable 
    {
        string GetId();
        void SetId(string id);

        object SaveData();
        void LoadData(object data);
    }
}
