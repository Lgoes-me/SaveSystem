using UnityEngine;

namespace ink.Save
{
    public abstract class SaveableBehaviour : MonoBehaviour, ISaveable
    {
        [SerializeField] private string _id = string.Empty;

        public string GetId() => _id;
        public void SetId(string id) => _id = id;

        public abstract void LoadData(object data);
        public abstract object SaveData();
    }
}