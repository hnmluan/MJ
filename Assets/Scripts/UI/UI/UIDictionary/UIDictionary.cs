﻿using System.Collections.Generic;
using UnityEngine;

public class UIDictionary : BaseUI
{
    [Header("UI Dictionary")]
    private static UIDictionary instance;
    public static UIDictionary Instance => instance;

    [SerializeField] private EDictionaryType dictionaryFilter = EDictionaryType.Enemies;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionary.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionary.instance = this;
    }

    protected override void Start()
    {
        ShowProfileSO();
        base.Start();
    }

    public virtual void ShowProfileSO()
    {
        this.ClearItems();

        if (dictionaryFilter == EDictionaryType.Enemies) ShowEnemyProfileSO();

        if (dictionaryFilter == EDictionaryType.NPCs) ShowNPCProfileSO();

        if (dictionaryFilter == EDictionaryType.Weapons) ShowDamageObjectProfileSO();
    }

    private void ShowEnemyProfileSO()
    {
        foreach (EnemyProfileSO item in GetEnemyProfileSO()) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    private void ShowNPCProfileSO()
    {
        foreach (NPCProfileSO item in GetNPCProfileSO()) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    private void ShowDamageObjectProfileSO()
    {
        foreach (DamageObjectSO item in GetDamageObjectProfileSO()) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    protected virtual void ClearItems() => UIDictionaryItemSpawner.Instance.ClearItems();

    public void SetDictionaryFilter(EDictionaryType dictionaryFilter)
    {
        this.dictionaryFilter = dictionaryFilter;
        this.ShowProfileSO();
    }

    private List<DamageObjectSO> GetDamageObjectProfileSO() => new List<DamageObjectSO>(Resources.LoadAll<DamageObjectSO>("DamageObject"));

    private List<NPCProfileSO> GetNPCProfileSO() => new List<NPCProfileSO>(Resources.LoadAll<NPCProfileSO>("NPC"));

    private List<EnemyProfileSO> GetEnemyProfileSO() => new List<EnemyProfileSO>(Resources.LoadAll<EnemyProfileSO>("Enemy"));
}