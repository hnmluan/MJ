using UnityEngine;

[System.Serializable]
public struct IntRange
{
    public int minValue;
    public int maxValue;

    public IntRange(int min, int max)
    {
        minValue = min;
        maxValue = max;
    }

    public int GetRandomValue()
    {
        return Random.Range(minValue, maxValue + 1);
    }
}
