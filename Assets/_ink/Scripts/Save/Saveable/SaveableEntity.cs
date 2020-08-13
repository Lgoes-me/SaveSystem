using System;
using System.Collections.Generic;
using UnityEngine;

namespace ink.Save
{
    public class SaveableEntity : MonoBehaviour
    {
        [SerializeField] private string _id = string.Empty;

        public string GetId() => _id;

        [ContextMenu("GenerateId")]
        public void SetId()
        {
            _id = Guid.NewGuid().ToString();

            foreach (var saveable in GetComponents<SaveableBehaviour>())
            {
                saveable.SetId(Guid.NewGuid().ToString());
            }
        }

        public object SaveData()
        {
            var state = new Dictionary<string, object>();
            
            foreach(var saveable in GetComponents<SaveableBehaviour>())
            {
                state[saveable.GetId()] = saveable.SaveData();
            }

            return state;
        }
            
        public void LoadData(object state)
        {
            var sateDictionary = (Dictionary<string, object>)state;

            foreach (var saveable in GetComponents<SaveableBehaviour>())
            { 
                if (sateDictionary.TryGetValue(saveable.GetId(), out object value))
                {
                    saveable.LoadData(value);
                }
            }
        }
    }
}
