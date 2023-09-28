using System;
using UnityEngine;

[Serializable]
public abstract class ItemActionData
{
    [SerializeField, HideInInspector] private string name;

    [SerializeField, HideInInspector] protected string keyActionLocalization;

    public string KeyActionLocalization { get => keyActionLocalization; }

    protected abstract void SetKeyActionLocalization();

    public abstract void Action();

    public ItemActionData()
    {
        SetDataName();
        SetKeyActionLocalization();
    }

    public void SetDataName() => name = GetType().Name;
}
