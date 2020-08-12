using UnityEngine;

namespace ink.Save
{
    public class SaveableBehaviour : MonoBehaviour, ISaveable
    {
        [SerializeField] private string _id = string.Empty;

        public string GetId() => _id;
        public void SetId(string id) => _id = id;

        public virtual object SaveData()
        {
            return null;
        }

        public virtual void LoadData(object data)
        {

        }
    }
}