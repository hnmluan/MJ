using System;
using UnityEngine;

[Serializable]
public abstract class ItemActionData
{
    [SerializeField, HideInInspector] private string name;

    public ItemActionData() => SetDataName();

    public void SetDataName() => name = GetType().Name;
}
