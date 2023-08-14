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
        if (dictionaryFilter == DictionaryFilter.Enemies) ShowEnemyProfileSO();
        if (dictionaryFilter == DictionaryFilter.NPCs) ShowNPCProfileSO();
    }

    private void ShowEnemyProfileSO()
    {
        if (!this.isOpen) return;
        this.ClearItems();

        EnemyProfileSO[] objectsArray = Resources.LoadAll<EnemyProfileSO>("Enemy");

        List<EnemyProfileSO> objList = new List<EnemyProfileSO>(objectsArray);

        foreach (EnemyProfileSO item in objList) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    private void ShowNPCProfileSO()
    {
        if (!this.isOpen) return;
        this.ClearItems();

        NPCProfileSO[] objectsArray = Resources.LoadAll<NPCProfileSO>("NPC");

        List<NPCProfileSO> objList = new List<NPCProfileSO>(objectsArray);

        foreach (NPCProfileSO item in objList) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    protected virtual void ClearItems() => UIDictionaryItemSpawner.Instance.ClearItems();

    public void SetDictionaryFilter(DictionaryFilter dictionaryFilter)
    {
        this.dictionaryFilter = dictionaryFilter;
        this.ShowProfileSO();
    }
}
