using System;
using ink.Save;

public class ExampleBehaviourA : SaveableBehaviour
{
    public string objectName;
    public int value;
    public float number;

    public override void LoadData(object data)
    {
        var savedData = (ExampleA)data;

        objectName = savedData.objectName;
        value = savedData.value;
        number = savedData.number;
    }

    public override object SaveData()
    {
        return new ExampleA
        {
            objectName = objectName,
            value = value,
            number = number
        };
    }

    [Serializable]
    private struct ExampleA
    {
        public string objectName;
        public int value;
        public float number;
    }
}
