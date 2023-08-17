using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;

public class UIDictionary : BaseUI, IActionDictionaryObserver
{
    [Header("UI Dictionary")]

    private static UIDictionary instance;
    public static UIDictionary Instance => instance;

    [SerializeField] private EDictionaryType dictionaryType = EDictionaryType.Enemies;
    public EDictionaryType DictionaryType => dictionaryType;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionary.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionary.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        Dictionary.Instance.AddObserver(this);
    }

    protected override void OnEnable()
    {
        dictionaryType = EDictionaryType.Enemies;
        this.ShowProfileSO();
    }

    public virtual void ShowProfileSO()
    {
        this.ClearItems();

        if (dictionaryType == EDictionaryType.Enemies) ShowEnemyProfileSO();

        if (dictionaryType == EDictionaryType.NPCs) ShowNPCProfileSO();

        if (dictionaryType == EDictionaryType.Weapons) ShowDamageObjectProfileSO();

        SortItems();
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
        this.dictionaryType = dictionaryFilter;
        this.ShowProfileSO();
    }

    private List<DamageObjectSO> GetDamageObjectProfileSO() => new List<DamageObjectSO>(Resources.LoadAll<DamageObjectSO>("DamageObject"));

    private List<NPCProfileSO> GetNPCProfileSO() => new List<NPCProfileSO>(Resources.LoadAll<NPCProfileSO>("NPC"));

    private List<EnemyProfileSO> GetEnemyProfileSO() => new List<EnemyProfileSO>(Resources.LoadAll<EnemyProfileSO>("Enemy"));

    protected virtual void SortItems()
    {
        int itemCount = UIDictionaryCtrl.Instance.Content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currObj = UIDictionaryCtrl.Instance.Content.GetChild(i);
            Transform nextObj = UIDictionaryCtrl.Instance.Content.GetChild(i + 1);

            UIItemDictionary currentUIObj = currObj.GetComponent<UIItemDictionary>();
            UIItemDictionary nextUIObj = nextObj.GetComponent<UIItemDictionary>();

            ScriptableObject currentProfile = currentUIObj.ItemDictionary;
            ScriptableObject nextProfile = nextUIObj.ItemDictionary;

            string currentName =
                currentProfile is EnemyProfileSO ? LocalizationManager.Localize((currentProfile as EnemyProfileSO).keyName) :
                currentProfile is DamageObjectSO ? LocalizationManager.Localize((currentProfile as DamageObjectSO).keyName) :
                LocalizationManager.Localize((currentProfile as NPCProfileSO).keyName);

            string nextName =
                nextProfile is EnemyProfileSO ? LocalizationManager.Localize((nextProfile as EnemyProfileSO).keyName) :
                nextProfile is DamageObjectSO ? LocalizationManager.Localize((nextProfile as DamageObjectSO).keyName) :
                LocalizationManager.Localize((nextProfile as NPCProfileSO).keyName);

            bool isSwap = false;

            isSwap = string.Compare(currentName, nextName) == 1;

            if (isSwap)
            {
                this.SwapItems(currObj, nextObj);
                isSorting = true;
            }
        }

        if (isSorting) this.SortItems();
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

    public void OnAddItem() => ShowProfileSO();

    public void OnSeenItem() => ShowProfileSO();
}
