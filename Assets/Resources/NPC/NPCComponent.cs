using System;
using UnityEngine;

[Serializable]
public abstract class NPCComponent
{
    [SerializeField, HideInInspector] private string name;

    public Type ComponentDependency { get; protected set; }

    public NPCComponent()
    {
        SetComponentName();
        SetComponentDependency();
    }

    public void SetComponentName() => name = GetType().Name;

    protected abstract void SetComponentDependency();
}
