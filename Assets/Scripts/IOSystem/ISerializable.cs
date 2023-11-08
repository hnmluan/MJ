using System;

[Serializable]
abstract class ISerializable
{
    public abstract T Serialize<T>(ISerializable iSerializable);
    public abstract ISerializable Deserialize<T>(T jsonData);
}
