using System;
using UnityEngine;

[Serializable]
public abstract class ItemActionData
{
    [SerializeField, HideInInspector] private string name;

    [SerializeField, HideInInspector] protected string KeyActionLocalization;

    protected abstract void SetKeyActionLocalization();

    public abstract void Action();

    public ItemActionData() => SetDataName();

    public void SetDataName() => name = GetType().Name;
}
