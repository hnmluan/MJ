using System;
using UnityEngine;

[Serializable]
public abstract class ItemData
{
    [SerializeField, HideInInspector] private string name;

    public ItemData() => SetDataName();

    public void SetDataName() => name = GetType().Name;
}
