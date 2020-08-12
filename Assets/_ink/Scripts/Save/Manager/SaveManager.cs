using System.Collections.Generic;
using UnityEngine;

namespace ink.Save
{
    public class SaveManager : MonoBehaviour
    {
        private SaveSystem saveSystem = new BinarySaveSystem();

        private void SaveData()
        {
            var data = saveSystem.LoadFile() as Dictionary<string, object>;

            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                data[saveable.GetId()] = saveable.SaveData();
            }

            saveSystem.SaveFile(data);
        }

        private void LoadData()
        {
            var data = saveSystem.LoadFile() as Dictionary<string, object>;

            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                if (data.TryGetValue(saveable.GetId(), out object value))
                {
                    saveable.LoadData(value);
                }
            }
        }
    }
}
