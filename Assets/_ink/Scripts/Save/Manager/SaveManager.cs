using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture; 

namespace ink.Save
{
    public class SaveManager : MonoBehaviour, IGameEventListener
    {
        public GameEventBase saveGameEvent;
        private SaveSystem saveSystem;

        private void Awake()
        {
            saveGameEvent.AddListener(this);
            saveSystem = new BinarySaveSystem();
        }

        public void OnEventRaised()
        {
            SaveData();
        }
        
        private void SaveData()
        {
            var data = saveSystem.LoadFile() as Dictionary<string, object>;

            if(data == null)
            {
                data = new Dictionary<string, object>();
            }

            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                data[saveable.GetId()] = saveable.SaveData();
            }

            saveSystem.SaveFile(data);
        }

        [ContextMenu("Load")]
        private void LoadData()
        {
            var data = saveSystem.LoadFile() as Dictionary<string, object>;

            if (data == null)
            {
                return;
            }
            
            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                if (data.TryGetValue(saveable.GetId(), out object value))
                {
                    saveable.LoadData(value);
                }
            }
        }

        public void OnDestroy()
        {
            saveGameEvent.RemoveListener(this);
        }
    }
}
