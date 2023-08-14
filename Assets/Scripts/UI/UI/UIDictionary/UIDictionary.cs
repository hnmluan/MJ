using System.Collections.Generic;
using UnityEngine;

public class UIDictionary : InitMonoBehaviour
{
    [Header("UI Dictionary")]
    private static UIDictionary instance;
    public static UIDictionary Instance => instance;

    protected bool isOpen = true;

    [SerializeField] private DictionaryFilter dictionaryFilter = DictionaryFilter.Enemies;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionary.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionary.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        ShowProfileSO();
        // this.Close();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        UIDictionaryCtrl.Instance.gameObject.SetActive(true);
        ShowProfileSO();
        this.isOpen = true;
    }

    public virtual void Close()
    {
        UIDictionaryCtrl.Instance.gameObject.SetActive(false);
        this.isOpen = false;
    }

    public virtual void ShowProfileSO()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        if (dictionaryFilter == DictionaryFilter.Enemies) ShowEnemyProfileSO();

        if (dictionaryFilter == DictionaryFilter.NPCs) ShowNPCProfileSO();
    }

    private void ShowEnemyProfileSO()
    {
        foreach (EnemyProfileSO item in GetEnemyProfileSO()) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    private void ShowNPCProfileSO()
    {
        foreach (NPCProfileSO item in GetNPCProfileSO()) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    protected virtual void ClearItems() => UIDictionaryItemSpawner.Instance.ClearItems();

    public void SetDictionaryFilter(DictionaryFilter dictionaryFilter)
    {
        this.dictionaryFilter = dictionaryFilter;
        this.ShowProfileSO();
    }

    private List<NPCProfileSO> GetNPCProfileSO() => new List<NPCProfileSO>(Resources.LoadAll<NPCProfileSO>("NPC"));

    private List<EnemyProfileSO> GetEnemyProfileSO() => new List<EnemyProfileSO>(Resources.LoadAll<EnemyProfileSO>("Enemy"));
}
