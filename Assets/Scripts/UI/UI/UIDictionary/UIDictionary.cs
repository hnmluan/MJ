using System.Collections.Generic;
using UnityEngine;

public class UIDictionary : InitMonoBehaviour
{
    [Header("UI Dictionary")]
    private static UIDictionary instance;
    public static UIDictionary Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionary.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionary.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        ShowItems();
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
        ShowItems();
        this.isOpen = true;
    }

    public virtual void Close()
    {
        UIDictionaryCtrl.Instance.gameObject.SetActive(false);
        this.isOpen = false;
    }

    public virtual void ShowItems()
    {
        if (!this.isOpen) return;
        this.ClearItems();

        EnemyProfileSO[] objectsArray = Resources.LoadAll<EnemyProfileSO>("Enemy");

        List<EnemyProfileSO> objList = new List<EnemyProfileSO>(objectsArray);

        foreach (EnemyProfileSO item in objList) UIDictionaryItemSpawner.Instance.SpawnItem(item);
    }

    protected virtual void ClearItems() => UIDictionaryItemSpawner.Instance.ClearItems();
}
