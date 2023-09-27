using System;
using UnityEngine;

[Serializable]
public abstract class ActionItemData
{
    [SerializeField, HideInInspector] private string name;

    [SerializeField, HideInInspector] protected string KeyActionLocalization;

    protected abstract void SetKeyActionLocalization();

    protected abstract void Action();

    public ActionItemData() => SetDataName();

    public void SetDataName() => name = GetType().Name;
}
