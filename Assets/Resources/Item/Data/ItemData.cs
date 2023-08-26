using System;
using UnityEngine;

[Serializable]
public abstract class ItemData
{
    [SerializeField, HideInInspector] private string name;

    public Type ComponentDependency { get; protected set; }

    public ItemData()
    {
        SetDataName();
        SetComponentDependency();
    }

    public void SetDataName() => name = GetType().Name;

    protected abstract void SetComponentDependency();
}
