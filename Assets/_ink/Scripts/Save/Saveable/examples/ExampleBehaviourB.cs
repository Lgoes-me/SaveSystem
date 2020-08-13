using System;
using ink.Save;

public class ExampleBehaviourB : SaveableBehaviour
{
    public string testString;
    public float value;

    public override void LoadData(object data)
    {
        var savedData = (ExampleB)data;

        testString = savedData.testString;
        value = savedData.value;
    }

    public override object SaveData()
    {
        return new ExampleB
        {
            testString = testString,
            value = value
        };
    }

    [Serializable]
    private struct ExampleB
    {
        public string testString;
        public float value;
    }
}
